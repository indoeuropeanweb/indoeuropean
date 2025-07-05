using indoeuropean.Class;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Force lowercase URL generation
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true; // optional
});

//builder.Services.AddControllersWithViews(options =>
//{
//    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
//});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});



var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    await next();
});

app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("X-Powered-By");
        return Task.CompletedTask;
    });

    await next();
});

// Force lowercase path before routing
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;

    if (!string.IsNullOrEmpty(path) && path != path.ToLowerInvariant())
    {
        var newPath = path.ToLowerInvariant();
        var query = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : string.Empty;

        context.Response.Redirect(newPath + query, permanent: true);
        return;
    }

    await next();
});

app.Use(async (context, next) =>
{
    var request = context.Request;

    // Only check path, not domain or query string
    var path = request.Path.Value;

    if (!string.IsNullOrEmpty(path) && path.Any(char.IsUpper))
    {
        var lowercasePath = path.ToLowerInvariant();
        var queryString = request.QueryString.HasValue ? request.QueryString.Value : "";

        var newUrl = $"{request.Scheme}://{request.Host}{lowercasePath}{queryString}";

        context.Response.Redirect(newUrl, permanent: true); // 301 redirect
        return;
    }

    await next.Invoke();
});

//app.Use(async (context, next) =>
//{
//    context.Response.Headers["Content-Security-Policy"] =
//        "default-src 'self'; " +
//        "script-src 'self' 'unsafe-inline' https://www.youtube.com https://cdn.jsdelivr.net https://cdnjs.cloudflare.com https://code.jquery.com; " +
//        "style-src 'self' https://fonts.googleapis.com 'unsafe-inline'; " +
//        "img-src 'self' data: https://i.ytimg.com https://www.youtube.com; " +
//        "font-src 'self' https://fonts.gstatic.com; " +
//        "frame-src https://www.youtube.com; " +
//        "object-src 'none'; " +
//        "base-uri 'self'; " +
//        "frame-ancestors 'none';";

//    await next();
//});




if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}


app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
