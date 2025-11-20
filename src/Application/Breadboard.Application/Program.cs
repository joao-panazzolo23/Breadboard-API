using System.Reflection;
using Breadboard.Application.Extensions;
using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.LightBridget.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerExtensions()
    .AddApiVersion()
    .AddCaching()
    .ConfigureJsonOptions()
    .AddQueryRepositories(builder.Configuration)
    .AddEntityFrameWork(builder.Configuration)
    .AddControllerNamingConvention()
    .AddLightBridge(typeof(User).Assembly)
    //any Domain class is required here , but the type informed is indifferent
    ;

var app = builder.Build();

app.AddSwaggerConfiguration()
    .MapEndpoints()
    .UseAuthentication()
    .UseAuthorization()

    //use routing is supposed to be the last since it breaks method chaining
    .UseRouting()
    ;

app.Services.EnsureDbCreation();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();

app.Run();