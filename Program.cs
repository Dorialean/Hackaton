using System.Text;
using Hackathon.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Verification/Auth";
        options.LogoutPath = "/Verification/LogOut";
    });

//Не успели доделать jwt аутентификацию (если раскомементить, оно, конечно, работает, но не связывает с бд на userPage)
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//        {
//            options.RequireHttpsMetadata = false;
//            options.Audience = "http://localhost:5001/";
//            options.Authority = "http://localhost:5000/";
//        });

//builder.Services.AddAuthorization(options =>
//{
//    var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
//        CookieAuthenticationDefaults.AuthenticationScheme,
//        JwtBearerDefaults.AuthenticationScheme);
//    defaultAuthorizationPolicyBuilder =
//        defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();
//    options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
//});

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

