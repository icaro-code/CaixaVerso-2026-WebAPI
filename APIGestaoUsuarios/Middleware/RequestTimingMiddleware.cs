namespace APIGestaoUsuarios.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        public RequestTimingMiddleware(RequestDelegate next)
        => _next = next;
        public async Task InvokeAsync(HttpContext context)
        {
            var inicio = DateTime.Now;
            await _next(context);
            var tempo = DateTime.Now - inicio;
            context.Response.Headers.Add("X-Response-Time", $"{tempo.TotalMilliseconds} ms");
        }
    }
}