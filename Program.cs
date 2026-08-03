using indoeuropean.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddSingleton<SitemapService>();

builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
    options.HttpsPort = 443;
});

builder.WebHost.ConfigureKestrel(options =>
{
    options.AddServerHeader = false;
});

var app = builder.Build();


if (args.Contains("generate-sitemap"))
{
    var service = app.Services.GetRequiredService<SitemapService>();

    var baseUrl = "https://indoeuropean.in";

    var controllerTypes = typeof(Program).Assembly.GetTypes()
        .Where(t => typeof(Controller).IsAssignableFrom(t));

    var urls = new List<string>();

    foreach (var controller in controllerTypes)
    {
        var controllerRoute = controller
            .GetCustomAttributes(typeof(RouteAttribute), true)
            .Cast<RouteAttribute>()
            .FirstOrDefault()?.Template;

        var methods = controller.GetMethods()
            .Where(m => m.IsPublic && !m.IsDefined(typeof(NonActionAttribute)));

        foreach (var method in methods)
        {
            var routeAttr = method
                .GetCustomAttributes(typeof(RouteAttribute), true)
                .Cast<RouteAttribute>()
                .FirstOrDefault();

            if (routeAttr != null)
            {
                string fullRoute = "";

                if (!string.IsNullOrEmpty(controllerRoute))
                    fullRoute += controllerRoute.Trim('/');

                if (!string.IsNullOrEmpty(routeAttr.Template))
                    fullRoute += "/" + routeAttr.Template.Trim('/');

                urls.Add(fullRoute.Trim('/'));
            }
        }
    }

    app.Use(async (context, next) =>
    {
        context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
        context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
        context.Response.Headers.Append(
            "Content-Security-Policy",
            "default-src 'self'; " +
            "script-src 'self'; " +
            "object-src 'none'; " +
            "base-uri 'self'; " +
            "frame-src 'self'; " +
            "frame-ancestors 'self';"
        );

        await next();
    });


    urls.Add("");

    urls = urls.Distinct().ToList();

    var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

    if (!Directory.Exists(wwwrootPath))
        Directory.CreateDirectory(wwwrootPath);

    var filePath = Path.Combine(wwwrootPath, "sitemap.xml");

    service.Generate(baseUrl, urls, filePath);

    Console.WriteLine("✅ Sitemap generated!");

    return;
}

// Configure HTTP pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append(
            "Cache-Control",
            "public,max-age=31536000");
    }
});

app.UseRouting();

// Remove server headers
app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("server");
        context.Response.Headers.Remove("X-Powered-By");
        context.Response.Headers.Remove("x-powered-by");

        return Task.CompletedTask;
    });

    await next();
});

app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        context.HttpContext.Response.Redirect("/");
    }

    await Task.CompletedTask;
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();