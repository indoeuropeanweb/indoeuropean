using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Configure MVC with lowercase URLs
builder.Services.AddControllersWithViews();
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});



builder.Services.AddHttpsRedirection(options =>
{
    options.RedirectStatusCode = StatusCodes.Status301MovedPermanently;
    options.HttpsPort = 443;
});

var app = builder.Build();

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    var req = context.Request;
    var host = req.Host.Host;

    if (host.Equals("www.indoeuropean.in", StringComparison.OrdinalIgnoreCase))
    {
        var newUrl = $"https://indoeuropean.in{req.Path}{req.QueryString}";
        context.Response.Redirect(newUrl, permanent: true);
        return;
    }

    await next();
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    app.UseHsts();
}

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // Cache static assets for 365 days
        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=31536000");
    }
});


app.Use(async (context, next) =>
{
    // Register a callback to run just before headers are sent
    context.Response.OnStarting(() =>
    {
        context.Response.Headers.Remove("Server");
        context.Response.Headers.Remove("X-Powered-By");
        // Also remove lowercase variants, just in case
        context.Response.Headers.Remove("server");
        context.Response.Headers.Remove("x-powered-by");
        return Task.CompletedTask;
    });

    await next();
});


// Core middleware pipeline
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}");

app.Run();
