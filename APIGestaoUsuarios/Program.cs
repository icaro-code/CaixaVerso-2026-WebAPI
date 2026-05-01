using APIGestaoUsuarios.Configurations;
using APIGestaoUsuarios.Filters;
using APIGestaoUsuarios.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configurações organizadas em extensões
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ResponseWrapperFilter>();
});

builder.Services.AddCustomJsonOptions();
builder.Services.RegisterServices();
builder.Services.AddCustomCors(builder.Configuration);
builder.Services.AddCustomSwagger();

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
