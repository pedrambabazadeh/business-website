APIs for different micro services of the application

=========================================

Steps to setup and run the application:

1. Navigate to the API directory:

    cd .\backend\API\

2. Install the packages at the bottom of this file

3. Create a .env file then copy and paste these data into it exactly as they are:

    ConnectionStrings__DefaultConnection="Data Source={PC Name}\\SQLEXPRESS;Initial Catalog={Database Name};Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"

    *Modify {PC Name} and {Database Name} in step 3 below!

    JWT__Issuer="http://localhost:5264"

    JWT__Audience="http://localhost:5264"

    JWT__SigninKey="odokw0384hf-1gy5g5ujkc%bv9v#(>vodbspt9n6g)vjsnq521%!#~3ij32rlf3-2fDF#@F#fe0w-=nfjnlmn8fyui3ndf_#(@G$W)fghrehj7luyghfefwfgrhjkyl.ilkyfjijlHJHDGRJKYT%Y^$&*^&O$54675u6uT%&5T$U%^4yR%U5RY"

4. Database Commands:

    Download SQL Server Management Studio (SSMS) from Microsoft: https://aka.ms/ssmsfullsetup
    How to setup SSMS tutorial: https://www.youtube.com/watch?v=SIQhe-yt3mA&list=PL82C6-O4XrHfrGOCPmKmwTO7M0avXyQKc&index=3

    dotnet ef migrations add Data

    dotnet ef database update

5. Run the program with Swagger to test the end points

    dotnet watch run

6. Run the program:

    dotnet run

    or you can give your own port

    dotnet run --urls="http://0.0.0.0:5000"

=========================================

dotnet Packages Command prompts:

dotnet add package Microsoft.EntityFrameworkCore

=========================================

NUGET Packages:

*Requires NUGET Gallery extenstion from pcislo
*Check version in API.csproj: <TargetFramework>net8.0</TargetFramework>

Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.Design
Microsoft.AspNetCore.Mvc.NewtonsoftJson
newtonsoft.Json
Microsoft.Extensions.identity.core
Microsoft.AspNetCore.Identity.EntityFrameworkCore
Microsoft.AspNetCore.Authentication.JwtBearer
