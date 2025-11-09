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