using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Application.Interfaces.Contexts;
using OnlineShop.Application.Services.Users.Commands.ChangeStatus;
using OnlineShop.Application.Services.Users.Commands.Create;
using OnlineShop.Application.Services.Users.Commands.Delete;
using OnlineShop.Application.Services.Users.Commands.Update;
using OnlineShop.Application.Services.Users.Queries.Get;
using OnlineShop.Application.Services.Users.Queries.GetRoles;
using OnlineShop.Persistence.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option =>
    option.UseSqlServer(@"Data Source=localHost\MyInstance; Initial Catalog=OnlineShop; User Id=mhmd; Password=13811381; Encrypt=false;")    
);
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IGetUserService, GetUserService>();
builder.Services.AddScoped<IGetUserRolesService, GetUserRolesService>();
builder.Services.AddScoped<ICreateUserService, CreateUserService>();
builder.Services.AddScoped<IDeleteUserService, DeleteUserService>();
builder.Services.AddScoped<IChangeUserStatusService, ChangeUserStatusService>();
builder.Services.AddScoped<IUpdateUserService, UpdateUserService>();

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Profile}/{action=Index}/{id?}");
});

app.Run();
