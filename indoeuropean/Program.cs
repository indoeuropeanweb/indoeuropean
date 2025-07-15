using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.WebUtilities;

var builder = WebApplication.CreateBuilder(args);

// Enable lowercase URL generation globally
builder.Services.AddControllersWithViews();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// Remove server header for security
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});

var app = builder.Build();

// Middleware: Security headers
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");

    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("X-Powered-By");
        return Task.CompletedTask;
    });

    await next();
});

// Middleware: Normalize www to non-www and force HTTPS
app.Use(async (context, next) =>
{
    var host = context.Request.Host.Host;
    var isHttps = context.Request.IsHttps;

    if (!isHttps || host.StartsWith("www."))
    {
        var redirectHost = host.Replace("www.", "");
        var redirectUrl = $"https://{redirectHost}{context.Request.Path}{context.Request.QueryString}";
        context.Response.Redirect(redirectUrl, permanent: true);
        return;
    }

    await next();
});

// ✅ Middleware: Normalize URL path casing (redirect uppercase to lowercase)
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;
    if (!string.IsNullOrEmpty(path) && Regex.IsMatch(path, "[A-Z]"))
    {
        var lowercasePath = path.ToLowerInvariant();
        var query = context.Request.QueryString;
        context.Response.Redirect($"{lowercasePath}{query}", permanent: true);
        return;
    }

    await next();
});

// ✅ Middleware: Remove trailing slashes (except for root)
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;
    if (!string.IsNullOrEmpty(path) && path != "/" && path.EndsWith("/"))
    {
        var newPath = path.TrimEnd('/');
        context.Response.Redirect($"{newPath}{context.Request.QueryString}", permanent: true);
        return;
    }

    await next();
});

// ✅ Middleware: Sort query string parameters
app.Use(async (context, next) =>
{
    var query = context.Request.QueryString.Value;

    if (!string.IsNullOrEmpty(query) && query.Contains("&"))
    {
        var parsedQuery = QueryHelpers.ParseQuery(query);
        var sortedQuery = parsedQuery.OrderBy(q => q.Key)
            .SelectMany(kv => kv.Value.Select(v => $"{kv.Key}={v}"))
            .ToArray();

        var sortedQueryString = "?" + string.Join("&", sortedQuery);

        if (query != sortedQueryString)
        {
            var redirectUrl = $"{context.Request.Path}{sortedQueryString}";
            context.Response.Redirect(redirectUrl, permanent: true);
            return;
        }
    }

    await next();
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
