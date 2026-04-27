namespace APIGestaoUsuarios.Filters
{
    public class ApiResponseFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var inicio = DateTime.Now;
        }
        var result = await next();
        var tempo = (DateTime.Now - inicio).TotalMilliseconds;
        if (result.Result is ObjectResult obj)
        {
            obj.Value = new
                {
                dados_resposta = obj.Value,
                timestamp_resposta = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"),
                tempo_da_resposta = $"{tempo} ms"
                };
        }
    }
}
    