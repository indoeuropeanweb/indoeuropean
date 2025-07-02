var builder = WebApplication.CreateBuilder(args);

// Force lowercase URL generation
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;
    if (path != path.ToLowerInvariant())
    {
        context.Response.Redirect(path.ToLowerInvariant() + context.Request.QueryString, true);
        return;
    }
    await next();
});

    // Force lowercase path before routing
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Optional: Redirect /home/index to /
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/home/index")
    {
        context.Response.Redirect("/", true);
        return;
    }

    await next();
});

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Optional: Add CSP header
//app.Use(async (context, next) =>
//{
//    context.Response.Headers.Append("Content-Security-Policy",
//        "default-src 'self'; " +
//        "script-src 'self' https://www.youtube.com https://www.google.com https://www.gstatic.com https://kit.fontawesome.com; " +
//        "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://cdnjs.cloudflare.com https://kit.fontawesome.com; " +
//        "font-src 'self' https://fonts.gstatic.com https://kit.fontawesome.com; " +
//        "img-src 'self' data: https://i.ytimg.com; " +
//        "frame-src https://www.youtube.com https://www.youtube-nocookie.com;"
//    );
//    await next();
//});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
