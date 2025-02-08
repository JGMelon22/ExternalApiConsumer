using System.Reflection;
using System.Text.Json;
using ExternalApiConsumer.Infrastructure.Interfaces;
using ExternalApiConsumer.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<JsonOptions>(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string apiBaseUrl = builder.Configuration["ServiceUri:ExternalPersonApi"]!;

builder.Services.AddRefitClient<IExternalPersonApi>().ConfigureHttpClient(c => c.BaseAddress = new Uri(apiBaseUrl));

builder.Services.AddScoped<IManagePersonService, ManagePersonService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
