public class ControleAcessosMiddleware
{
    private readonly RequestDelegate _next;

    public ControleAcessosMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        var metodo = context.Request.Method;
        var endpoint = $"{context.Request.Path}{context.Request.QueryString}";

        Console.WriteLine($"{timestamp} | {metodo} | {endpoint}");

        await _next(context);
    }
}
