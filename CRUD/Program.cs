using CRUD.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(c => c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost::44466", "https://localhost:7200", "localhost:5200").AllowAnyHeader()));

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowEverything",
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:44466",
                              "https://localhost:7200",
                              "https://localhost:5200");
                          policy.WithMethods("POST", "GET","DELETE", "PUT");
                          policy.WithHeaders("Content-Type");
                      });
});


builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowEverything");
app.MapControllerRoute(name: "Api", pattern: "api/{controller}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");


//app.MapFallbackToFile("index.html"); ;

app.Run();
