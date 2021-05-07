# V-Mechanic
V-Mechanic application

[![Bintray](https://img.shields.io/badge/license-vmechanics-blue.svg?style=flat-square?maxAge=2592000)]()
[![Bintray](https://img.shields.io/badge/made%20with-dotnetcore3.1-blue.svg?style=flat-square?maxAge=2592000)]()

## Features
- Backlog dashboard
- Admin management
- Admin user management
- User profile 
- Manage multi-users base on their account type
- Sorting, Searching, and pagination
- Estimate base on kilometer
- Users location feature
- Admin details endpoint
- Payment process (payment method, etc)
- Database seeder (users)
- and a lot more...

## Note on Issues
Please post issues here that are related to this code base and also feel free to ask me any question. If you clone THIS repo and there are issues, then you can submit for help.

## Usage

### Prerequisites
  ```
  Build the project (for vscode: dotnet build)
  dotnet restore
  ```
  ### Seed Database
  ```
    Sample User Login

    admin@vmehanic.com (Admin)
    Pa$$w0rd
  ```

 ### Run Migration
  ```
    dotnet ef migrations add InitialIdentity -p Infrastructure -s API/ -o Identity/Migrations -c AppIdentityDbContext (vscode)
    dotnet ef migrations add InitialCreate -p Infrastructure -s API/ -o Data/Migrations -c DataContext (vscode)
    Add-Migration InitialIdentity -c AppIdentityDbContext -o Identity/Migrations -p Infrastructure (visual studio)
    Add-Migration InitialCreate -c DataContext -o Data/Migrations -p Infrastructure (visual studio)
  ```

### Architecture
 `Monolithic architecture` 
 `REST API`

### Design pattern
`Task-based Asynchronous Pattern(TAP)`
`Dependency Injection Pattern (DI)` 
`Repository Pattern`

### Technology stack
- DotNetCore API
- SQL Server (Development)
- MySQL Server (Production)
- Entity Framework Core

### Projects
 - `API` ASP.NET Core 3.1 API
 - `Core` Reusable class library targeting .NET Standard 2.1
 - `Infrastructure` Reusable class library targeting .NET Standard 2.1

### Middleware
- `IpRateLimitOptions` Rate limiting enables you to control the number of requests that a client can make to an endpoint.
- `AddHttpCacheHeaders` For caching in both requests and responses

### Contributors
- [Ifeanyi Eze](mailto:emmatex4yall@hotmail.com)
- Chukwunonyerem Maxwell



