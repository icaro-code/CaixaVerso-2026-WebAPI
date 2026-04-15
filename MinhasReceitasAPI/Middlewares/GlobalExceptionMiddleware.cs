public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no caminho: {context.Request.Path}");
            Console.WriteLine($"Detalhes: {ex.Message}");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("Ocorreu um erro no processamento da requisição.");
        }
    }
}
