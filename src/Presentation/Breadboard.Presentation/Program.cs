using Breadboard.Application.Extensions;
using Breadboard.Presentation.ExceptionHandler;
using Breadboard.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurity(builder.Configuration)
    .AddDatabase(builder.Configuration)
    .AddDocuments(builder.Environment)
    .AddControllersScheme()
    .AddCaching()
    .AddApplication()
    .AddExceptions().AddModelBindingExceptions();

var app = builder.Build();

app.UseExceptionHandler()
    .UseStaticFiles()
    .UseSecurity()
    .UseHttpsRedirection()
    .UseRouting()
    .UseDocumentation()
    .UseDatabase()
    .UseControllers();

app.Run();