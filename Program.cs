using PortfolioApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();
builder.Services.AddHttpClient();


var port = Environment.GetEnvironmentVariable("PORT") ?? "80"; // Render ustawia PORT automatycznie
builder.WebHost.UseUrls($"http://*:{port}");


builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PortfolioDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication(); // Dodaj to, jeśli masz logowanie
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");






using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PortfolioDbContext>();
    var adminEmail = builder.Configuration["AdminUser:Email"];
    var adminPassword = builder.Configuration["AdminUser:Password"];

   
        context.Database.EnsureCreated();
        DbInitializer.Seed(context, adminEmail, adminPassword);
    


 
}



app.Run();
