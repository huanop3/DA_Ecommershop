using System.Net;
using System.Security.Claims;
using System.Text;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using web_api_base.Models.dbEcommer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Thêm dịch vụ cho Blazor Server
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


// Đọc connection string từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("EbayConnection");
//Kết nối db
builder.Services.AddDbContext<ECommerContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));
//Bật giao diện authentication 
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    // 🔥 Thêm hỗ trợ Authorization header tất cả api
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Nhập token vào ô bên dưới theo định dạng: Bearer {token}"
    });

    // 🔥 Định nghĩa yêu cầu sử dụng Authorization trên từng api
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


//Thêm middleware authentication
var privateKey = builder.Configuration["jwt:Secret-Key"];
var Issuer = builder.Configuration["jwt:Issuer"];
var Audience = builder.Configuration["jwt:Audience"];
// Thêm dịch vụ Authentication vào ứng dụng, sử dụng JWT Bearer làm phương thức xác thực
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    // Thiết lập các tham số xác thực token
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        // Kiểm tra và xác nhận Issuer (nguồn phát hành token)
        ValidateIssuer = true,
        ValidIssuer = Issuer, // Biến `Issuer` chứa giá trị của Issuer hợp lệ
                              // Kiểm tra và xác nhận Audience (đối tượng nhận token)
        ValidateAudience = true,
        ValidAudience = Audience, // Biến `Audience` chứa giá trị của Audience hợp lệ
                                  // Kiểm tra và xác nhận khóa bí mật được sử dụng để ký token
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey)),
        // Sử dụng khóa bí mật (`privateKey`) để tạo SymmetricSecurityKey nhằm xác thực chữ ký của token
        // Giảm độ trễ (skew time) của token xuống 0, đảm bảo token hết hạn chính xác
        ClockSkew = TimeSpan.Zero,
        // Xác định claim chứa vai trò của user (để phân quyền)
        RoleClaimType = ClaimTypes.Role,
        // Xác định claim chứa tên của user
        NameClaimType = ClaimTypes.Name,
        // Kiểm tra thời gian hết hạn của token, không cho phép sử dụng token hết hạn
        ValidateLifetime = true
    };
});
//DI Service JWT
builder.Services.AddScoped<JwtAuthService>();
// Thêm dịch vụ Authorization để hỗ trợ phân quyền người dùng
builder.Services.AddAuthorization();

//DI Repository

//DI UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//DI Service

builder.Services.AddHttpClient();
//Add storeage
builder.Services.AddBlazoredLocalStorage();
//Sử dụng httpcontext từ blazor server
builder.Services.AddHttpContextAccessor();
//Cấu hình CORS
builder.Services.AddCors(option =>
{
    option.AddPolicy("allow_origin", policy =>
    {
        // WithOrigins("https://localhost:5208", "https://login.cybersoft.edu.vn", "http://127.0.0.1:9999")
        // policy.AllowAnyOrigin(); //Cho phép tất cả các client đều có thể gửi dữ liệu đến server
        policy.AllowAnyOrigin().AllowAnyHeader() //Cho phép rq tất cả header
            .AllowAnyMethod() //Cho phép rq tất cả method (POST,PUT,GET,DELETE,OPTION)
            .AllowCredentials(); ////Cho phép cookie...
    });
    // option.AddDefaultPolicy();
});
//DI Service cho Blazor Server

//deploy cài đặt lắng nghe pport 80
builder.WebHost.UseUrls("http://*:80");


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// app.UseCors("allow_origin"); //Sử dụng cors cho tất cả các request từ client đến server
app.UseHttpsRedirection();
app.MapControllers();




//blazor    
app.UseStaticFiles();
app.UseRouting();
//Phân quyền
app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub(); // SignalR hub cho Blazor Server
app.MapFallbackToPage("/_Host"); // Trang mặc định cho Blazor
app.Urls.Add("http://*:80");
app.Run();


