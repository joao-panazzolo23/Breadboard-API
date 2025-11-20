using System.Reflection;
using Breadboard.Application.Extensions;
using Breadboard.Infra.LightBridget.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerExtensions()
    .AddApiVersion()
    .AddCaching()
    .ConfigureJsonOptions()
    .AddQueryRepositories()
    .AddEntityFrameWork(builder.Configuration)
    .AddControllerNamingConvention()
    .AddLightBridge(Assembly.GetExecutingAssembly())
    ;

var app = builder.Build();


//create database & apply pending migrations
app.Services.EnsureDbCreation();
app.UseRouting();
app.AddSwaggerConfiguration()
    .MapEndpoints()
    .UseAuthentication()
    .UseAuthorization();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();

app.Run();