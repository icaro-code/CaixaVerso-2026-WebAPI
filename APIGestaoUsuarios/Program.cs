using APIGestaoUsuarios.Aplication.Services;
using APIGestaoUsuarios.Filters;
using APIGestaoUsuarios.Interfaces;
using APIGestaoUsuarios.Middleware;
using APIGestaoUsuarios.Repositories;
using APIGestaoUsuarios.Services;
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

// Controllers + filtro global
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ResponseWrapperFilter>();
});

// Registro dos serviços e repositórios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<AuditoriaService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração de CORS usando appsettings.json
var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy.WithOrigins(allowedOrigins ?? Array.Empty<string>())
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseAuthorization();
app.UseCors("FrontendPolicy");
app.MapControllers();

app.Run();
