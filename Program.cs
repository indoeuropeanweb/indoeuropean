var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/home/index")
    {
        context.Response.Redirect("/", permanent: true);
        return;
    }
    await next();
});

app.Use(async (context, next) =>
{
    var request = context.Request;

    // Normalize path (lowercase + no /home/index)
    var path = request.Path.Value;

    if (path != null)
    {
        var normalizedPath = path.ToLowerInvariant();

        if (normalizedPath == "/home/index")
        {
            context.Response.Redirect("/", true);
            return;
        }

        if (normalizedPath != path)
        {
            context.Response.Redirect(normalizedPath, true);
            return;
        }
    }

    await next();
});

app.Use(async (context, next) =>
{
    context.Response.Headers.Append("Content-Security-Policy",
        "default-src 'self'; " +
        "script-src 'self' https://www.youtube.com https://www.google.com https://www.gstatic.com https://kit.fontawesome.com; " +
        "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://cdnjs.cloudflare.com https://kit.fontawesome.com; " +
        "font-src 'self' https://fonts.gstatic.com https://cdnjs.cloudflare.com https://kit.fontawesome.com; " +
        "img-src 'self' data: https://i.ytimg.com; " +
        "frame-src https://www.youtube.com https://www.youtube-nocookie.com;"
    );
    await next();
});



// Custom middleware to enforce lowercase URLs
app.Use(async (context, next) =>
{
    var path = context.Request.Path.Value;
    var queryString = context.Request.QueryString.Value;

    if (!string.IsNullOrEmpty(path) && path != path.ToLowerInvariant())
    {
        var lowercaseUrl = path.ToLowerInvariant() + queryString;
        context.Response.Redirect(lowercaseUrl, permanent: true);
        return;
    }

    await next();
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
