namespace APIGestaoUsuarios.Middleware
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestLoggingMiddleware(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext context)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            await _next(context);
            watch.Stop();
            Console.WriteLine($"[LOG] {context.Request.Method} {context.Request.Path} - {watch.ElapsedMilliseconds} ms");
        }
    }
}