using Breadboard.Application.Extensions;
using Breadboard.Domain.Users.Entities;
using Breadboard.Infra.COPS.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(User).Assembly;

builder.Services.AddSwaggerExtensions()
    .AddApiVersion()
    .AddCaching()
    .ConfigureJsonOptions()
    .AddQueryRepositories(assembly)
    .AddEntityFrameWork(builder.Configuration)
    .AddControllerNamingConvention()
    .AddCops(assembly)
    //any Domain class is required here, but wich one is completelly indifferent
    ;

var app = builder.Build();

app.AddSwaggerConfiguration()
    .MapEndpoints()
    .UseAuthentication()
    .UseAuthorization()
    .UseStaticFiles()

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