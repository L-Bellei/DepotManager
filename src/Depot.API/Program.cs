using Depot.API.Configuration.DependencyInjection;
using Depot.API.Configuration.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjection(builder.Configuration);
builder.Services.AddSwaggerConfiguration();
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerWithNiceUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
