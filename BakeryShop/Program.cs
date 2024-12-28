﻿


using BakeryShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
// .NET 6/7/8 (Program.cs)


builder.Services.AddHttpClient();
builder.Services.AddHttpClient("BakeryApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7056/api/"); 
});

builder.Services.AddHttpClient<ApiService>();


builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<CartService>(); // Thêm dịch vụ CartService vào container

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/BakeryShop/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BakeryShop}/{action=Index}/{id?}");

app.Run();
