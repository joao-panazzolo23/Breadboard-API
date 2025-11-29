using Breadboard.Application.Extensions;
using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.COPS.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Abstractions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;
using Breadboard.Infra.Scalar.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddAuthenticationController()
    .AddApiVersion()
    .AddCaching()
    .AddEntityFrameWork(builder.Configuration)
    .AddControllerNamingConvention()
    .AddQueryRepositories(typeof(IQueryRepository).Assembly) //query infra. assembly
    .AddCops(typeof(User).Assembly) //domain assembly
    .AddOpenApi();


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