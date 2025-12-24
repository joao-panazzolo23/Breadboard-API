using Breadboard.Application.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;
using Breadboard.Infra.Scalar.Extensions;


var builder = WebApplication.CreateBuilder(args);


builder.AddServices();

var app = builder.Build();

app.UsePipelines();

app.AddScalarInterface();

app.Services.MigrateDataBase();

app.MapControllers();
app.Run();