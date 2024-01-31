using BLL.LogicServices;
using DAL.Data;
/*using DAL.DataMapping;*/
using DAL.DataServices;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity;*/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
/*builder.Services.AddSingleton<ICarLogic, CarLogic>();*/
builder.Services.AddScoped<ICarLogic, CarLogic>();
/*builder.Services.AddSingleton<ICarDataDAL, CarDataDAL>();*/
builder.Services.AddScoped<ICarDataDAL, CarDataDAL>();
/*builder.Services.AddSingleton<IDapperORM, DapperORM>();*/
builder.Services.AddDbContext<CarDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CarDb"), b => b.MigrationsAssembly("SampleNtierArchitecture"));
});

/*builder.Services.AddDbContext<CarDbContext>();*/

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
    /*pattern: "{controller=Car}/{action=CarList}/{id?}");*/
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
