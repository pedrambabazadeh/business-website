using API.Models;
using API.MicroServices.Users.Src.DTOs;
using API.MicroServices.Users.Src.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Web;

namespace API.MicroServices.Users.Src.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly ITokenService tokenService;
        private readonly IEmailService emailService;

        public AccountController(
            UserManager<AppUser> userManager, SignInManager<AppUser> signinManager,
            ITokenService tokenService, IEmailService emailService)
        {
            this.userManager = userManager;
            this.signinManager = signinManager;
            this.tokenService = tokenService;
            this.emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                                {
                                    FirstName = registerDto.FirstName,
                                    LastName = registerDto.LastName,
                                    UserName = registerDto.Username,
                                    Email = registerDto.Email,
                                    Category = registerDto.Category
                                };

                var createdUser = await userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await userManager.AddToRoleAsync(appUser, "Admin");

                    if (!roleResult.Succeeded)
                        return StatusCode(500, roleResult.Errors);

                    return Ok (
                        new NewUserDto
                        {
                            Username = appUser.UserName,
                            Email = appUser.Email,
                            Token = tokenService.Create(appUser)
                        }
                    );
                }

                return StatusCode(500, createdUser.Errors);
            }

            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.UserName.ToLower() == loginDto.Username.ToLower());

            if (user is null)
                return Unauthorized("Username not found and/or password is not valid");

            var result = await signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
                return Unauthorized("Username not found and/or password is not valid");

            return Ok (
                new NewUserDto
                {
                    Username = user.UserName,
                    Email = user.Email,
                    Token = tokenService.Create(user)
                }
            );
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> SendPasswordResetLink([FromBody] SendPasswordResetLinkDto sendPasswordResetLinkDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == sendPasswordResetLinkDto.Email.ToLower());

            if (user is null)
                return Unauthorized("User with this email doesn't exist");

            var resetToken = await userManager.GeneratePasswordResetTokenAsync(user);

            var encodedToken = HttpUtility.UrlEncode(resetToken);

            var resetUrl = $"http://localhost:5264/api/account/reset-password?token={encodedToken}&email={user.Email}";

            var emailSent = await emailService.SendResetPasswordEmail(user.Email, resetUrl); // Need company email to test with.

            if (!emailSent)
                return StatusCode(500, "Failed to send reset password link. Try again!");

            return Ok("Password reset link has been sent to your email.");
        }

        // Need company email to test with.
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] PasswordResetDto passwordResetDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await userManager.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == passwordResetDto.Email.ToLower());

            if (user is null)
                return Unauthorized("Invalid email");

            var decodedToken = HttpUtility.UrlDecode(passwordResetDto.EncodedResetToken);

            var result = await userManager.ResetPasswordAsync(user, decodedToken, passwordResetDto.NewPassword);

            if (!result.Succeeded)
                return BadRequest("Password reset failed. Please ensure the token is correct and the new password meets the requirements.");

            return Ok("Password has been successfuly reset.");
        }
    }
}