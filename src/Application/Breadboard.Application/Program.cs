using Breadboard.Application.Extensions;

//I think program.cs is good enough by now. It could get even better, but I have no idea how.
var builder = WebApplication.CreateBuilder(args);

builder.AddSecurity()
    .AddDatabase()
    .AddDocuments()
    .AddControllersScheme()
    .AddCaching()
    .AddMediator();

var app = builder.Build();

app.UseSecurity()
    .UseStaticFiles()
    .UseHttpsRedirection()
    .UseRouting()
    .UseDocumentation()
    .UseDatabase()
    .UseControllers();

app.Run();