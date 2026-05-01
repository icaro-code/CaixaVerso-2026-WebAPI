namespace APIGestaoUsuarios.Configurations
{
    public static class JsonConfig
    {
        public static void AddCustomJsonOptions(this IServiceCollection services)
        {
            services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = new Utils.SnakeCaseNamingPolicy();
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
                options.JsonSerializerOptions.Converters.Add(new Utils.DateTimeConverter());
            });
        }
    }
}