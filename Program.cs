using Microsoft.AspNetCore.Mvc.Filters;
using EjercitacionMVC.Filters;
using EjercitacionMVC.Services;
using EjercitacionMVC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Agrego filtros de accion
builder.Services.AddScoped<FiltrosAccion>();

builder.Services.AddScoped<IFormatNumber, FormatNumber>();

builder.Services.AddDbContext<HrContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskEntity}/{action=Index}/{id?}");

app.Run();
