using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using docmatchMS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add custom services
var azureEndpoint = builder.Configuration["AzureCognitiveServices:Endpoint"]
    ?? throw new ArgumentNullException("AzureCognitiveServices:Endpoint", "Azure Cognitive Services Endpoint is not configured.");
var azureApiKey = builder.Configuration["AzureCognitiveServices:ApiKey"]
    ?? throw new ArgumentNullException("AzureCognitiveServices:ApiKey", "Azure Cognitive Services API Key is not configured.");

builder.Services.AddSingleton(new SimilarityService(azureEndpoint, azureApiKey));
builder.Services.AddScoped<FileProcessingService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();