using APIGestaoUsuarios.Utils; // garante acesso ao DateTimeConverter e SnakeCaseNamingPolicy
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuração de serialização JSON
builder.Services.Configure<JsonOptions>(options =>
{
    // Usa snake_case para propriedades
    options.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();

    // Ignora campos nulos na saída
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

    // Usa o conversor customizado de DateTime
    options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
