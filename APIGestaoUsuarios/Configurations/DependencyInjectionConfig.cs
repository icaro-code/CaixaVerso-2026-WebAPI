using APIGestaoUsuarios.Aplication.Services;
using APIGestaoUsuarios.Interfaces;
using APIGestaoUsuarios.Repositories;
using APIGestaoUsuarios.Services;

namespace APIGestaoUsuarios.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddSingleton<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<AuditoriaService>();
        }
    }
}
