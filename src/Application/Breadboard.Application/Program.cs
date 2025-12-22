using Breadboard.Application.Extensions;
using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.COPS.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Abstractions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;
using Breadboard.Infra.Scalar.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddOpenApiConfig()
    .AddCaching()
    .AddEntityFrameWork(builder.Configuration)
    .AddControllerNamingConvention()
    .AddQueryRepositories(typeof(IQueryRepository).Assembly) //query infra. assembly
    .AddCops(typeof(User).Assembly) //domain assembly
    .AddOpenApi()
    // .AddApiVersion();
    ;
var app = builder.Build();

app.AddScalarInterface(builder)
    .UseAuthentication()
    .UseAuthorization() //needs to come after authentication
    .UseStaticFiles()
    .UseHttpsRedirection()
    //use routing is supposed to be the last since it breaks method chaining
    .UseRouting()
    ;
app.Services.MigrateDataBase();
app.MapControllers();
app.Run();