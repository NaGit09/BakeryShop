using Bakery_API.Interfaces;
using Bakery_API.Models;
using Bakery_API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Bakery_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                // Cấu hình Swagger để hỗ trợ gửi token trong header
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Description = "Enter 'Bearer' followed by a space and your token"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            // Cấu hình chuỗi kết nối
            builder.Services.AddSqlServer<BakeryShopContext>(builder.Configuration.GetConnectionString("Shop"));

            // Cấu hình Dependency Injection (DI)
            builder.Services.AddScoped<IUser, UserServices>();
            builder.Services.AddScoped<IProduct, ProductServices>();
            builder.Services.AddScoped<ICart, CartServices>(); // Đăng ký DI cho CartServices
            builder.Services.AddScoped<TokenServices>();
            builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
            builder.Services.AddHttpContextAccessor();

            // Cấu hình JWT
            var secretKey = builder.Configuration.GetValue<string>("AppSettings:SecretKey");
            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(secretKey);

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
                        ClockSkew = TimeSpan.Zero,
                    };


                });

            // Cấu hình CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMVC", policy =>
                {
                    policy.WithOrigins("https://localhost:7223")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            // Cấu hình Session

            builder.Services.AddDistributedMemoryCache(); // Cần thiết để hỗ trợ session
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Thời gian tồn tại của session
                options.Cookie.HttpOnly = true; // Bảo mật cookie session
                options.Cookie.IsEssential = true; // Yêu cầu cookie phải tồn tại
            });

            // tùy chọn tuần tự hóa JSON để hỗ trợ chu kỳ tham chiếu
            //builder.Services.AddControllers()
            //.AddJsonOptions(options =>
            //{
            //    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //});



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseSession(); // Thêm middleware session

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
