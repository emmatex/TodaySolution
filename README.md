# Today Solution

[![Bintray](https://img.shields.io/badge/license-todaysolution-blue.svg?style=flat-square?maxAge=2592000)]()
[![Bintray](https://img.shields.io/badge/made%20with-dotnetcore5.0-blue.svg?style=flat-square?maxAge=2592000)]()

## Features
- Upload Csv 
- Get All Patients
- pagination
- Get Single

### Prerequisites
  ```
  Build the project 
  ```
  
 ### Run Migration
  ```
    Add-Migration InitialCreate -c PatientContext -o Migrations -p Infrastructure
	Update-Database
  ```

### Architecture
 `Monolithic architecture` 
 `REST API`



### Technology stack
- DotNetCore API
- SQL Server (Development)
- Entity Framework Core

### Projects
 - `API` ASP.NET Core 5.0 API
 - `Core` Reusable class library targeting .NET Standard 5.0
 - `Infrastructure` Reusable class library targeting .NET Standard 5.0


