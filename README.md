# AuthFunction

AuthFunction is a web application that provides authentication and authorization functionalities using ASP.NET Core Identity. This project includes role-based access control with roles such as `admin`, `hr`, and `dev`.

## Usage

This project demonstrates how to implement authentication and authorization in an ASP.NET Core application. Users can register, log in, and be assigned roles. The application also includes role-based access control for different parts of the application.

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Getting Started

Follow these steps to set up and run the project:

### 1. Clone the repository

```sh
git clone https://github.com/your-username/auth-function-umi.git
cd auth-function-umi
```

### 2. Set up the database

#### 2.1. Run Microsoft SQL Server in Docker

Run the following command to start a Microsoft SQL Server container:

```sh
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourStrong!Passw0rd' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2019-latest
```

#### 2.2. Update the connection string

Update the connection string in `appsettings.json` to use SQL Server:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;Database=aspnet-AuthFunction;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

### 3. Run database migrations

Run the following commands to create and apply the database migrations:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Seed the database

The roles `admin`, `hr`, and `dev` will be seeded automatically when the application starts in development mode. This is handled in the `Program.cs` file.

### 5. Run the application

Run the following command to start the application:

```sh
dotnet run
```

Open your browser and navigate to [https://localhost:5001](https://localhost:5001) to see the application in action.

## Database ER Diagram

The database schema for this project includes the following tables:

- **AspNetUsers**: Stores user information.
- **AspNetRoles**: Stores role information.
- **AspNetUserRoles**: Stores the relationship between users and roles.
- **AspNetUserClaims**: Stores claims for users.
- **AspNetRoleClaims**: Stores claims for roles.
- **AspNetUserLogins**: Stores external login information for users.
- **AspNetUserTokens**: Stores tokens for users.

### ER Diagram Representation

```
+------------------+       +------------------+
|   AspNetUsers    |       |    AspNetRoles   |
+------------------+       +------------------+
| UserId (PK)      |       | RoleId (PK)      |
| UserName         |       | Name             |
| Email            |       | NormalizedName   |
| ...              |       | ...              |
+------------------+       +------------------+
         |                          |
         |                          |
         +--------------------------+
         |                          |
+------------------+       +------------------+
| AspNetUserRoles  |       | AspNetUserClaims |
+------------------+       +------------------+
| UserId (FK)      |       | Id (PK)          |
| RoleId (FK)      |       | UserId (FK)      |
+------------------+       | ClaimType        |
                           | ClaimValue       |
                           +------------------+
```

## Project Structure

- **Controllers**: Contains the MVC controllers for handling HTTP requests.
- **Data**: Contains the `ApplicationDbContext` class for database access.
- **Models**: Contains the model classes used in the application.
- **Views**: Contains the Razor views for rendering HTML pages.
- **Areas/Identity**: Contains the identity-related pages and logic.

## Features

- User registration and login
- Role-based access control
- Email confirmation
- Password reset

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or bug fixes.
