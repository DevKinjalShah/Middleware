namespace Middleware.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;  
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("");
            await context.Response.WriteAsync("this is from custom middleware\n");
            await _next(context);
        }

      

    }


    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }


}
