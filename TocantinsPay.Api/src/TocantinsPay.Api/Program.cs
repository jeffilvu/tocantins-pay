using TocantinsPay.Api.Extensions;
using TocantinsPay.Api.Middlewares;
using TocantinsPay.Application;
using TocantinsPay.Core;
using TocantinsPay.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddDomain()
    .AddInfrastructure()
    .AddApplication()
    .AddValidators()
    .AddMiddlewares();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.DocumentTitle = "API Profissional - V1";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Profissional - V1");
    });
}

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseAuthorization();

app.UseMiddleware<GlobalExceptionHandler>();

app.MapControllers();

app.Run();
