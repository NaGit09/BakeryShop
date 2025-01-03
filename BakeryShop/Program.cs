using BakeryShop.Filter;
using BakeryShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Cấu hình session
builder.Services.AddDistributedMemoryCache(); // Dùng bộ nhớ để lưu trữ session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian hết hạn session
    options.Cookie.HttpOnly = true; // Cookie chỉ có thể truy cập qua HTTP
    options.Cookie.IsEssential = true; // Cookie là cần thiết cho hoạt động của ứng dụng
});

builder.Services.AddHttpClient();
builder.Services.AddHttpClient("BakeryApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7056/api/");
}); 
builder.Services.AddScoped<ApiService>();
builder.Services.AddScoped<LoginFilter>();
builder.Services.AddScoped<CartService>();



var app = builder.Build();

// Cấu hình HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/BakeryShop/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// Cấu hình sử dụng session
app.UseSession();  // Lệnh này cần được gọi để sử dụng session

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=BakeryShop}/{action=Index}/{id?}");

app.Run();
