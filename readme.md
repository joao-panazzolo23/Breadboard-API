# Welcome to Breadboard!

[![.NET](https://img.shields.io/badge/.NET-9-blue)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF%20Core-7.0-blue)](https://learn.microsoft.com/ef/core/)

A custom API project using **.NET 9** based on **Domain-Driven Design (DDD)**.

---

## 🚀 Getting started

### Clone this repository

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

## Frameworks used:

<ul>
<li>
 Dapper (Queries) & EF Core (Writings);
</li>
<li>
 xUnit & Moq & Bogus for Unit testing;
</li>
<li>
 Scalar & OpenAPI for documentation;
</li>
<li>
 Mapperly for Command/Query to Entity;
</li>
<li>
 Fluent Validations & Fluent Results for input validations;
</li>
<li>
 Martin Othamar's Source Generator Mediator (Mediator Pattern);
</li>
</ul>

## Designs & Microdesigns
<ul>

<li>
 Domain Driven Design
</li>
<li>
 Clean Architecture
</li>
<li> 
 Mediator Pattern (GoF directives-friendly)
</li>
<li>
 Result Pattern
</li>
<li>
 Command & Query Resposability Segregation (CQRS)
</li>
<li>
OpenAPI Documentation
</li>
</ul>


## Migrations

    Step 01 - cd src/Infrastructure/Breadboard-API.Infrastructure.PostgreSQL/
    Step 02 - dotnet ef migrations add <NAME> -o Migrations -s ../../Application/Breadboard-API.Application/Breadboard-API.Application.csproj
    Step 03 - dotnet ef database update  -s ../../Application/Breadboard-API.Application/Breadboard-API.Application.csproj
