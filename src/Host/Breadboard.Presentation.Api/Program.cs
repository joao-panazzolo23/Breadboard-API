using Breadboard.Application.Extensions;
using Breadboard.Presentation.Extensions;
using BuildingBlocks.Mqtt;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSecurity(builder.Configuration)
    .AddDatabase(builder.Configuration)
    .AddDocuments(builder.Environment)
    .AddControllersScheme()
    .AddCaching()
    .AddApplication()
    .AddExceptions()
    .AddMqttDependencies()
    ;

var app = builder.Build();

await app.MigrateDatabase();

await app.ConnectMqttClient();

app.UseStaticFiles()
    .UseSecurity()
    .UseHttpsRedirection()
    .UseRouting()
    .UseDocumentation()
    .UseControllers()
    .UseExceptionHandler()
    ;

app.Run();