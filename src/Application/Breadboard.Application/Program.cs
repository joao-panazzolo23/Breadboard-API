using Breadboard.Application.Extensions;
using Breadboard.Infra.PostgreSQL.Extensions;

//TODO: DESCOBRIR OQ EH OPEN API E PQ USAR ESSA BOMBA EM .NET 9
var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddOpenApi();
builder.Services.AddSwaggerExtensions();
builder.Services.AddApiVersion();
builder.Services.AddCaching();
builder.AddControllerNamingConvention();
//services.AddHttpContextAccessor(); later
builder.Services.ConfigureJsonOptions();

//entity dependencies & repositories
builder.Services.AddEntityFrameWork(builder.Configuration);

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