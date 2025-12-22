# Welcome to Breadboard!

[![.NET](https://img.shields.io/badge/.NET-9-blue)](https://dotnet.microsoft.com/) 
[![EF Core](https://img.shields.io/badge/EF%20Core-7.0-blue)](https://learn.microsoft.com/ef/core/) 

A custom API project using **.NET 9** based on **Domain-Driven Design (DDD)**.

---

## 🚀 Getting started

###  Clone this repository
```
git clone https://github.com/joao-panazzolo23/Breadboard-API
```

### Configuring Database
Change appsettings.json with your desired database (Remember: This was made using PostgreSQL):
 ```
"DefaultConnection": "Host=localhost;Port=5432;Database=breadboard;Username=postgres;Password=postgres;"
 ```

Framework version: This project is using .NET 9, but it is intended to get an upgrade soon.

### Adding a new project (VS Code)
```
dotnet new <projectType> -n <name> (creates a new project)
```
and then add to solution using 
```
dotnet sln add <newCsprojPath> (adds to main solution)
```
###

## Framworks used:

<p>
 Dapper (Queries) & EF Core (Writings)
</p>
<p>
 xUnit & Moq & Bogus for Unit testing
</p>
<p>
 Scalar & OpenAPI for documentation.
</p>

## Designs & Microdesigns
<p>
 Domain-Driven Design
</p>
<p> 
 Mediator Pattern (GoF directives-friendly)
</p>
<p>
 Result Pattern
</p>
<p>
 Command & Query Resposability Segregation (CQRS
</p>
<p>
OpenAPI Documentation
</p>





##
Migrations

    Step 01 - cd src/Infrastructure/Breadboard-API.Infrastructure.PostgreSQL/
    Step 02 - dotnet ef migrations add <NAME> -o Migrations -s ../../Application/Breadboard-API.Application/Breadboard-API.Application.csproj
    Step 03 - dotnet ef database update  -s ../../Application/Breadboard-API.Application/Breadboard-API.Application.csproj

