using Finanzas_APP.Data;
using Finanzas_APP.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Contexto DB
builder.Services.AddDbContext<ContextoDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connexion")));

builder.Services.AddDbContext<ContextoDb>(ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICuentaRepositorio, CuentaRepositorio>();


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