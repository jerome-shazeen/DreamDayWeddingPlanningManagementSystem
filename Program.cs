using DreamDayWeddingPlanningManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session support.
builder.Services.AddSession();

// Configure cookie policy to mark cookies as secure and enforce SameSite.
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    // No consent needed for non-essential cookies
    options.CheckConsentNeeded = context => false;
    // Enforce a strict SameSite policy.
    options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
    // Mark cookies as secure so they're only sent over HTTPS.
    options.Secure = Microsoft.AspNetCore.Http.CookieSecurePolicy.Always;
});

// Configure EF Core with SQL Server (update the connection string as needed)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Add cookie policy middleware to ensure cookies are configured correctly.
app.UseCookiePolicy();

app.UseRouting();

app.UseSession();  // Enable session middleware

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
