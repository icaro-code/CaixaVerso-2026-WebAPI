namespace APIGestaoUsuarios.Configurations
{
    public static class CorsConfig
    {
        public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

            services.AddCors(options =>
            {
                options.AddPolicy("FrontendPolicy", policy =>
                {
                    policy.WithOrigins(allowedOrigins ?? Array.Empty<string>())
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }
    }
}

// Política de CORS:
// - Apenas origens confiáveis definidas no appsettings.json podem acessar a API.
//   Isso garante segurança em produção, evitando chamadas de sites não autorizados.
// - AllowAnyHeader e AllowAnyMethod foram liberados para dar flexibilidade ao frontend,
//   que precisa enviar tokens de autenticação e usar diferentes verbos HTTP.
// - Em desenvolvimento, pode-se usar AllowAnyOrigin para facilitar testes,
//   mas em produção apenas os domínios oficiais são permitidos.
