using API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Blog>(x => x.HasKey(b => new { b.AppUserId }));
            
            builder.Entity<Blog>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.Blogs)
                .HasForeignKey(p => p.AppUserId);

            List<IdentityRole> roles = new() {
                new IdentityRole {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}