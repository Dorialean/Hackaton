using Hackathon.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
if(Environment.OSVersion.ToString() == "Microsoft Windows NT 10.0.19043.0")
{
    builder.Services.AddDbContext<HackathonDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresPC")));
}
else if (Environment.OSVersion.ToString() == "Linux")
{
    builder.Services.AddDbContext<HackathonDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresLaptop")));
}
else
{
    //Добавь сюда свою строку подключения
    builder.Services.AddDbContext<HackathonDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresLaptop")));
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

