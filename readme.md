# Welcome to Breadboard!

[![.NET](https://img.shields.io/badge/.NET-9-blue)](https://dotnet.microsoft.com/) 
[![EF Core](https://img.shields.io/badge/EF%20Core-7.0-blue)](https://learn.microsoft.com/ef/core/) 
[![Template Status](https://img.shields.io/badge/template-ready-brightgreen)]()

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
 dotnet new install .
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

Dapper (Queries) & EF Core (Writings)
xUnit & Moq & Bogus for Unit testing
Scalar & OpenAPI for documentation.


## Designs & Microdesigns

Domain-Driven Design
Mediator Pattern (GoF directives-friendly)
Result Pattern
Command & Query Resposability Segregation 
OpenAPI Documentation


##
Migrations

    Step 01 - cd src/Infrastructure/Icone.Infrastructure.PostgreSQL/
    Step 02 - dotnet ef migrations add <NAME> -o Migrations -s ../../Application/Breadboard-API.Application/Icone.Application.csproj
    Step 03 - dotnet ef database update  -s ../../Application/Icone.Application/Breadboard-API.Application.csproj

