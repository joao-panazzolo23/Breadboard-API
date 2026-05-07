using Breadboard.Application.Extensions;
using Breadboard.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddSecurity(builder.Configuration)
    .AddDatabase(builder.Configuration)
    .AddDocuments(builder.Environment)
    .AddControllersScheme()
    .AddCaching()
    .AddApplication()
    .AddExceptions()
    ;

var app = builder.Build();

await app.MigrateDatabase();

app.UseStaticFiles()
    .UseSecurity()
    .UseHttpsRedirection()
    .UseRouting()
    .UseDocumentation()
    .UseControllers()
    .UseExceptionHandler()
    ;

app.Run();