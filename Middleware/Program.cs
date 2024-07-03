using Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Inline Middleware 

app.Use(async (context, next) =>
{
    // Do something with the context before passing to the next middleware
    await context.Response.WriteAsync("Inline Middleware - Before\n");
    await next.Invoke();
    // Do something with the context after the next middleware has processed the request
    await context.Response.WriteAsync("Inline Middleware - After\n");
});

app.UseMiddleware<CustomMiddleware>();
app.UseCustomMiddleware();
app.Use(async (context, next) =>
{
    // Do something with the context before passing to the next middleware
    await context.Response.WriteAsync("Inline Middleware - Before 1\n");
    await next.Invoke();
    // Do something with the context after the next middleware has processed the request
    await context.Response.WriteAsync("Inline Middleware - After 1\n");  
});

//Map: Branches based on a specific request path. Useful when the request path structure is known and fixed.
//Example: Handling different sections of a website like /api or /admin.
app.MapWhen(context => context.Request.Query.ContainsKey("branch"), branchApp =>
{
    branchApp.Run(async context =>
    {
        await context.Response.WriteAsync("Handled by the conditional branch based on query parameter 'branch'");
    });
});
//MapWhen: Branches based on a predicate that evaluates the HttpContext. Useful for more dynamic and conditional routing based on request properties.
//Example: Handling requests differently based on query parameters or custom headers.
app.MapWhen(context => context.Request.Headers.ContainsKey("X-Custom-Header"), headerBranchApp =>
{
    headerBranchApp.Run(async context =>
    {
        await context.Response.WriteAsync("Handled by the conditional branch based on 'X-Custom-Header'");
    });
});
// For adding terminal middleware that doesn't call the next middleware.
app.Run(async context =>
{
    await context.Response.WriteAsync("Terminal Middleware \n");
});

app.Run();