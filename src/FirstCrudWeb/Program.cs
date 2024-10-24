using FirstCrud.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Westwind.AspNetCore.LiveReload;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FirstCrudDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerStrConnection")));



// Add services to reload
builder.Services.AddLiveReload();


// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
