using indoeuropean.Class;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(args);

// Force lowercase URL generation
builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options => options.LowercaseUrls = true);


builder.Services.AddControllersWithViews(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(new SlugifyParameterTransformer()));
});

var app = builder.Build();

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
