var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<PasswordHasher>();
builder.Services.AddCorsPolicy(builder.Configuration);

var app = builder.Build();

app.UseMiddleware<RequestTimingMiddleware>();
app.UseCors("FrontendPolicy");
app.MapControllers();
app.Run();