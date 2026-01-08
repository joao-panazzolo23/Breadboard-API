using Breadboard.Application.Extensions;
using Breadboard.Presentation.Extensions;

//I think program.cs is good enough by now. It could get even better, but I have no idea how.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSecurity(builder.Configuration)
    .AddDatabase(builder.Configuration)
    .AddDocuments(builder.Environment)
    .AddControllersScheme()
    .AddCaching()
    .AddApplication()
    .AddExceptionHandling();

var app = builder.Build();

app.UseStaticFiles()
    .UseSecurity()
    .UseHttpsRedirection()
    .UseRouting()
    .UseDocumentation()
    .UseDatabase()
    .UseControllers()
    .UseExceptionHandler();

app.Run();