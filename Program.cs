using Hackathon.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Verification/Auth";
    });
builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

//Which connection string use to connect to PostgreSQL
if (Environment.OSVersion.ToString() == "Microsoft Windows NT 10.0.19043.0")
{
    builder.Services.AddDbContext<HackathonDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresPC")));
}
else if (Environment.OSVersion.ToString() == "Unix 5.15.0.52")
{
    builder.Services.AddDbContext<HackathonDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresLaptop")));
}
else
{
    builder.Services.AddDbContext<HackathonDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresMac")));
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();

