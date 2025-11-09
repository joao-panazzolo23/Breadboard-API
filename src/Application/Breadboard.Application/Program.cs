using Breadboard.Application.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.PostgreSQLDapper.Extensions;

var builder = WebApplication.CreateBuilder(args);

//services.AddHttpContextAccessor(); later
//builder.Services.AddOpenApi();

builder.Services.AddSwaggerExtensions()
    .AddApiVersion()
    .AddCaching()
    .ConfigureJsonOptions()
    .AddQueryRepositories()
    .AddEntityFrameWork(builder.Configuration);


builder.AddControllerNamingConvention();

var app = builder.Build();

//create database & apply pending migrations
app.Services.EnsureDbCreation();
app.UseRouting();
app.AddSwaggerConfiguration();
app.MapEndpoints();
//authenticate & authorize
app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
// }

app.UseHttpsRedirection();

app.Run();