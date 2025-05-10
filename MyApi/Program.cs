using MyApi.Data;
using MyApi.Repositories;
using MyApi.Services;
using Microsoft.OpenApi.Models;
using OpenAI;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "My API",
        Version = "v1"
    });
});

builder.Services.AddSingleton<OpenAIClient>(sp =>
{
    var apiKey = builder.Configuration["OpenAI:ApiKey"];
    return new OpenAIClient(apiKey);
});


builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<ProductoService>();
builder.Services.AddScoped<PedidoService>();
builder.Services.AddScoped<DbContextDapper>();
builder.Services.AddScoped<ClienteRepository>();
builder.Services.AddScoped<ProductoRepository>();
builder.Services.AddScoped<PedidoRepository>();
builder.Services.AddScoped<AIService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); 

app.Run();