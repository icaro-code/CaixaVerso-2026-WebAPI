var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Middlewares
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<ControleAcessosMiddleware>();

// Endpoints
app.MapReceitaEndpoints();

app.Run();