
# Pomelo Template - API

A .NET API template using Vertical slice architecture / Screaming architecture, Swagger, FastEndpoints, MediatR, Docker, and following the RERP pattern.

---

### How to Use

#### **Install the template**
1. To install the template, run the following command:
   ```bash
   dotnet new --install Pomelo.Template.API::{version}
   ```
2. This will install the template from NuGet.org.

#### **Create a new project**
1. Create a new API project based on the template:
   ```bash
   dotnet new pomelo-api -n YourApiName
   ```
2. You're ready to go!

### Alternative Method
If you prefer, you can clone the repository and install the template manually:
1. Clone the repository.
2. Navigate to the `Pomelo.Template.API` folder.
3. Run:
   ```bash
   dotnet new install ./
   ```
4. Create a new project:
   ```bash
   dotnet new pomelo-api -n YourApiName
   ```
5. You're ready to go!

### Features
- User registration and login with username and password
- EF extension for pagination
- Result Pattern

### Notes:
- **EF Core Configuration:**  
  The template does not include EF Core configuration by default, as it is designed to be database-provider agnostic. You must install and configure EF Core in `DatabaseExtension.cs` according to your specific database needs.

---

**Available exclusively for .NET 8.0**
