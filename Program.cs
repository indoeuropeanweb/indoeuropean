using indoeuropean.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

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

var app = builder.Build();
app.UseHttpsRedirection();

//app.Use(async (context, next) =>
//{
//    var req = context.Request;
//    var host = req.Host.Host;

//    if (host.Equals("www.indoeuropean.in", StringComparison.OrdinalIgnoreCase))
//    {
//        var newUrl = $"https://indoeuropean.in{req.Path}{req.QueryString}";
//        context.Response.Redirect(newUrl, permanent: true);
//        return;
//    }

//    await next();
//});

app.UseRouting();

if (args.Contains("generate-sitemap"))
{
    var service = app.Services.GetRequiredService<SitemapService>();

    var baseUrl = "https://indoeuropean.in";

    var endpoints = app.Services.GetRequiredService<EndpointDataSource>();

    var urls = new List<string>();

    var controllerTypes = typeof(Program).Assembly.GetTypes()
        .Where(t => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(t));

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
                var actionRoute = routeAttr.Template;

                string fullRoute = "";

                if (!string.IsNullOrEmpty(controllerRoute))
                    fullRoute += controllerRoute.Trim('/');

                if (!string.IsNullOrEmpty(actionRoute))
                    fullRoute += "/" + actionRoute.Trim('/');

                urls.Add(fullRoute.Trim('/'));
            }
        }
    }

    // ✅ Add homepage manually
    urls.Add("");

    // ✅ Remove duplicates
    urls = urls.Distinct().ToList();

    foreach (var url in urls)
    {
        Console.WriteLine(url); // debug
    }

    var wwwrootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

    if (!Directory.Exists(wwwrootPath))
    {
        Directory.CreateDirectory(wwwrootPath);
    }

    var filePath = Path.Combine(wwwrootPath, "sitemap.xml");

    service.Generate(baseUrl, urls, filePath);

    Console.WriteLine("✅ Sitemap generated!");
    return;
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
    }
});

app.Use(async (context, next) =>
{
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("X-Powered-By");
        context.Response.Headers.Remove("server");
        context.Response.Headers.Remove("x-powered-by");
        return Task.CompletedTask;
    });

    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
