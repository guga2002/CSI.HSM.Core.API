using GuestSide.Application.Services.AdvertisementType;
using GuestSide.Application.Services.Advertismenet;
using GuestSide.Application.Services.Feadback;
using GuestSide.Core.Data;
using GuestSide.API.CustomMiddlwares;
using GuestSide.Application.Services.Guest;
using GuestSide.Application.Services.Item.DI;
using GuestSide.Application.Services.Notification.DI;
using GuestSide.Application.Services.Room.DI;
using Microsoft.OpenApi.Models;
using GuestSide.Application.Services.Hotel;
using Core.Persistance.Cashing.Inject;
using Core.Persistance.LoggingConfigs;
using Microsoft.EntityFrameworkCore;
using AuthorizationHelper.Injection.CommonServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Application.Services.LogService.DI;
using Core.Application.Services.Staff.Cart.DI;
using Core.Application.Services.Staff.Category.DI;
using Core.Application.Services.Staff.Staff.DI;
using Core.Application.Services.Task.Category.DI;
using Core.Application.Services.Task.Status.DI;
using Core.Application.Services.Task.Task.DI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
 .AddApplicationPart(typeof(AuthorizationHelper.Minimal.Controllers.AuthorizationController).Assembly)
 .AddApplicationPart(typeof(AuthorizationHelper.Minimal.Controllers.UsersController).Assembly)
 .AddApplicationPart(typeof(AuthorizationHelper.Minimal.Controllers.RolesController).Assembly)
 .AddControllersAsServices();
builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GuestSideDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CSICOnnect"));
});

builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(2044);
        options.ListenAnyIP(2045, listenOptions => listenOptions.UseHttps());
    });

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey ?? throw new ArgumentNullException("define secret key"))),
        ClockSkew = TimeSpan.Zero,
    };
});


builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Core.Api", Version = "v1" });

        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
        c.OperationFilter<AddHotelIdHeaderParameter>();
    });


    builder.Services.AddRedisCash("192.168.0.28"?? throw new ArgumentNullException("Redis Key Is not defined"));

    builder.Services.InjectAdvertisment();
    builder.Services.AddAdvertisementType();
    builder.Services.InjectFeadbacks();

    builder.Services.InjectStaffCategory();
    builder.Services.InjectCartToStaff();
    builder.Services.InjectStaffs();

    builder.Services.InjectTaskCategory();
    builder.Services.InjectTasks();
    builder.Services.InjectTaskStatus();
    builder.Services.InjectGuest();
    builder.Services.InjectCart();
    builder.Services.InjectItemCategory();
    builder.Services.InjectItem();
    builder.Services.InjectLog();
    builder.Services.InjectGuestNotification();
    builder.Services.InjectNotification();
    builder.Services.InjectStaffNotification();
    builder.Services.InjectQrCode();
    builder.Services.InjectRoomCategory();
    builder.Services.InjectRoom();

builder.Services.InjectCommonServices(builder.Configuration);

    builder.Services.InjectHotel();

    builder.Services.InjectLocation();

    builder.Services.AddHttpContextAccessor();

    builder.Logging.ClearProviders();

builder.Services.InjectSeriLog();

builder.Services.InjectFeadbacks();


var app = builder.Build();
    app.UseStaticFiles();
    app.UseAuthentication();
    app.UseAuthorization();

    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Api V1");
        options.RoutePrefix = "swagger";
        //options.InjectJavascript("/swagger-voice-search.js");
    });

app.UseMiddleware<TenantMiddleware>();
//app.UseMiddleware<RequestLoggerMiddleware>();
app.UseMiddleware<CashingMiddlwares>();

 
    app.UseHttpsRedirection();
    app.MapControllers();
    await app.RunAsync();