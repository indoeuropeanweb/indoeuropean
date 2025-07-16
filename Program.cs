using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Routing;

var builder = WebApplication.CreateBuilder(args);

// ✅ Configure MVC with lowercase URLs
builder.Services.AddControllersWithViews();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// ✅ Remove 'Server' header from Kestrel (security best practice)
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
});

var app = builder.Build();

// ✅ Security headers
//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Append("X-Frame-Options", "DENY");
//    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
//    context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");
//    context.Response.Headers.Append("X-XSS-Protection", "1; mode=block");
//    context.Response.Headers.Append("Permissions-Policy", "geolocation=(), microphone=()");

//    context.Response.OnStarting(() =>
//    {
//        context.Response.Headers.Remove("Server");
//        context.Response.Headers.Remove("X-Powered-By");
//        return Task.CompletedTask;
//    });

//    await next();
//});

// ✅ Canonical URL middleware (lowercase + remove slash + sort query)
//app.Use(async (context, next) =>
//{
//    var originalPath = context.Request.Path.Value ?? "/";
//    var originalQuery = context.Request.QueryString.Value ?? "";

//    string normalizedPath = originalPath;
//    string normalizedQuery = originalQuery;
//    bool redirectNeeded = false;

//    // Normalize path to lowercase and remove trailing slash (not for root)
//    if (originalPath != "/" && originalPath != originalPath.ToLowerInvariant())
//    {
//        normalizedPath = originalPath.ToLowerInvariant();
//        redirectNeeded = true;
//    }

//    if (normalizedPath.EndsWith("/") && normalizedPath != "/")
//    {
//        normalizedPath = normalizedPath.TrimEnd('/');
//        redirectNeeded = true;
//    }

//    // Normalize query string (sorted order)
//    if (originalQuery.Contains("&"))
//    {
//        var parsedQuery = QueryHelpers.ParseQuery(originalQuery);
//        var sortedQuery = parsedQuery.OrderBy(q => q.Key)
//            .SelectMany(kv => kv.Value.Select(v => $"{kv.Key}={v}"))
//            .ToArray();

//        normalizedQuery = "?" + string.Join("&", sortedQuery);

//        if (normalizedQuery != originalQuery)
//        {
//            redirectNeeded = true;
//        }
//    }

//    // Perform safe redirect if needed
//    if (redirectNeeded)
//    {
//        var finalUrl = normalizedPath + normalizedQuery;
//        var currentUrl = originalPath + originalQuery;

//        if (finalUrl != currentUrl)
//        {
//            context.Response.Redirect(finalUrl, permanent: true);
//            return;
//        }
//    }

//    await next();
//});

// ✅ Exception handling & HSTS
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}

// ✅ Core middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// ✅ MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
