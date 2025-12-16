<h1>Welcome to Breadboard! </h1>

<p> This is supposed to be an stupidly overengineered project just for fun and games. </p>

<h2>
to add a new project
</h2>

<p>
-> dotnet new <projectType> -n <name> (creates a new project)
</p>
<p>
-> dotnet sln add <newCsprojPath> (adds to main solution)
</p>
<p>
-> (if extensions are needed) dotnet add Application/Breadboard.Application reference <pathToYourProject.csproj> (reference your project to your web API)
</p>

<h2>
to run your migrations
</h2>

<p>
-> cd src\Infrastructure\Infrastructure.PostgreSQL (select your entity framework project, assuming you're at root pathway)
</p>

<p>
-> <strong> dotnet ef migrations add <migrationName> -p src\Infrastructure\Infrastructure.PostgreSQL\Infrastructure.PostgreSQL.csproj </strong>
</p>


<p>
there's no need to apply migrations to database since it is done whenever has started running. This API is also supposed to be running with Breadboard's Angular project. You can find it in here: https://github.com/joao-panazzolo23/breadboard

</p>

<h1> Tecnologies & Patterns used: </h1>

<h4>
   COPS - A Custom and lightweight Mediator (According to GOF directives) 
</h4>
 
<h4>
  Command & Query Responsabilty Segregation (CQRS) using Dapper & Entity framework
</h4>
  
<h4>
   API Versioning control, automapper for endpoints and entities, custom Attributes for kebab-case endpoints 
</h4>
 
<h4>
  Domain Driven Design (DDD), SOLID, DRY, KISS. The goal was to keep performance and scalability at the higher standards possible, even it is not going to scale.
</h4>

<h4>
    Dotnet 9.0 (I'm thinking about updating to 10 since it was release this month)
</h4>

<h4>
   Swagger & Swagger UI (for API documentation) // Scalar + OpenAPI
</h4>


<h4>
  Generic repositories for entity and SQL Builders for Dapper
</h4>

