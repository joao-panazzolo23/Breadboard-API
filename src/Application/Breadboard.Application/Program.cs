using Breadboard.Application.Extensions;
using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.COPS.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;
using Breadboard.Infra.Scalar.Extensions;

var builder = WebApplication.CreateBuilder(args);

//any Domain class is required. Types are indifferent, the project Assembly is what matters.
var assembly = typeof(User).Assembly;
builder.AddAuthenticationController()
    .AddApiVersion()
    .AddCaching()
    .AddEntityFrameWork(builder.Configuration)
    .AddControllerNamingConvention()
    .AddQueryRepositories(assembly)
    .AddCops(assembly)
    .AddOpenApi();


//we're now using Scalar + OpenAPI to match .NET new Standards 
// builder.AddSwaggerExtensions()
//app.AddSwaggerConfiguration() 

var app = builder.Build();

app.AddScalarInterface(builder)
    .UseAuthentication()
    .UseAuthorization() //this needs to come after authentication
    .UseStaticFiles()
    //use routing is supposed to be the last since it breaks method chaining
    .UseRouting()
    ;

app.Services.EnsureDbCreation();
app.MapControllers();

app.UseHttpsRedirection();

app.Run();