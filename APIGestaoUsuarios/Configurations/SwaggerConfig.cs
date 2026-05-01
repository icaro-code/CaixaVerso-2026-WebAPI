namespace APIGestaoUsuarios.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddCustomSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }
    }
}
