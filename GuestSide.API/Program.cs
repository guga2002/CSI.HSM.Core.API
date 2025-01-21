using GuestSide.Application.Services.AdvertisementType;
using GuestSide.Application.Services.Advertismenet;
using GuestSide.Application.Services.Feadback;
using GuestSide.Core.Data;
using GuestSide.API.CustomMiddlwares;
using GuestSide.Application.Services.Item.DI;
using GuestSide.Application.Services.Notification.DI;
using GuestSide.Application.Services.Room.DI;
using Microsoft.OpenApi.Models;
using GuestSide.Application.Services.Hotel;
using Core.Persistance.Cashing.Inject;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Application.Services.LogService.DI;
using Core.Application.Services.Language.Di;
using Core.Application.Services.Payment.PaymentOption.DI;
using Core.Application.Services.Payment.RestaurantOrderPayment.DI;
using Core.Application.Services.Restaurant.DI;
using Core.Application.Services.Staff.Cart.DI;
using Core.Application.Services.Staff.Category.DI;
using Core.Application.Services.Staff.Staff.DI;
using Core.Application.Services.Task.Category.DI;
using Core.Application.Services.Task.Status.DI;
using Core.Application.Services.Task.Task.DI;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Core.Interfaces.UniteOfWork;
using Core.Infrastructure.Repositories.UniteOfWork;
using Core.Core.Interfaces.Audio;
using Core.Infrastructure.Repositories.Audio;
using Core.Core.Interfaces.Guest;
using Core.Infrastructure.Repositories.Guest;
using Core.Core.Interfaces.Item;
using Core.Infrastructure.Repositories.Item;
using Core.Application.Services.Item.DI;
using Core.Application.Services.Guest.Injection;
using Core.Persistance.LoggingConfigs;
using AuthorizationHelper.Injection.CommonServices;
using Core.Application.Services.Audio.Injection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
 //.AddApplicationPart(typeof(AuthorizationHelper.Minimal.Controllers.AuthorizationController).Assembly)
 //.AddApplicationPart(typeof(AuthorizationHelper.Minimal.Controllers.UsersController).Assembly)
 //.AddApplicationPart(typeof(AuthorizationHelper.Minimal.Controllers.RolesController).Assembly)
 //.AddControllersAsServices();
builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

builder.Services.AddHttpContextAccessor();

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


    builder.Services.AddRedisCash("127.0.0.1" ?? throw new ArgumentNullException("Redis Key Is not defined"));

    builder.Services.InjectAdvertisment();
    builder.Services.AddAdvertisementType();
    builder.Services.InjectFeadbacks();

    builder.Services.InjectGuest();

    builder.Services.InjectHotel();
    builder.Services.InjectLocation();

    builder.Services.InjectCart();
    builder.Services.InjectItemCategory();
    builder.Services.InjectItem();

    builder.Services.AddLanguagePack();

    builder.Services.InjectLog();

    builder.Services.InjectNotification();
    builder.Services.InjectGuestNotification();
    builder.Services.InjectStaffNotification();

    builder.Services.InjectPaymentOption();

    builder.Services.InjectRestaurantOrderPaymen();

    builder.Services.AddRestaurantCartServices();
    builder.Services.AddRestaurantServices();
    builder.Services.AddRestaurantItemCategory();
    builder.Services.AddRestaurantItem();
builder.Services.AddRestaurantItemToCart();

builder.Services.InjectQrCode();
builder.Services.InjectRoomCategory();
builder.Services.InjectRoom();

builder.Services.InjectCartToStaff();


builder.Services.InjectStaffCategory();
builder.Services.InjectStaffs();

builder.Services.InjectTaskCategory();
builder.Services.InjectTaskStatus();
builder.Services.InjectTasks();
builder.Services.AddScoped<IUniteOfWork, UniteOfWorkRepository>();

builder.Services.AddGuestActiveLanguage();
builder.Services.InjectOrderableItem();

builder.Services.InjectGuestStatus();

builder.Services.InjectAudioResponse();

builder.Services.InjectAudioResponseCategory();

builder.Services.InjectCommonServices(builder.Configuration);

builder.Logging.ClearProviders();
builder.Services.InjectSeriLog();

builder.Services.AddScoped(typeof(IAdditionalFeaturesRepository<>), typeof(AdditionalFeaturesRepository<>));


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