using Breadboard.Application.Extensions;
using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.COPS.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;

var builder = WebApplication.CreateBuilder(args);

//any Domain class is required. Types are indifferent, the project Assembly is what matters.
var assembly = typeof(User).Assembly;

builder.Services
    .AddSwaggerExtensions()
    .AddApiVersion()
    .AddCaching()
    .AddEntityFrameWork(builder.Configuration)
    .AddControllerNamingConvention()
    .AddQueryRepositories(assembly)
    .AddCops(assembly)
    ;

var app = builder.Build();

app.AddSwaggerConfiguration()
    // .MapEndpoints()
    .UseAuthentication()
    .UseAuthorization()
    .UseStaticFiles()

    //use routing is supposed to be the last since it breaks method chaining
    .UseRouting()
    ;

app.Services.EnsureDbCreation();
app.MapControllers();

// todo: see what changes here
// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();

app.Run();