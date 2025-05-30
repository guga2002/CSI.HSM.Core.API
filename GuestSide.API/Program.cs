using Microsoft.OpenApi.Models;
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
using Core.Application.Services.Task.Status.DI;
using Core.Application.Services.Task.Task.DI;
using Core.Infrastructure.Repositories.AbstractRepository;
using Core.Infrastructure.Repositories.UniteOfWork;
using Core.Application.Services.Guest.Injection;
using Core.Application.Services.Task.TaskLog.Startup;
using Core.Application.Services.Audio.Injection;
using Core.Application.Services.Item.DI;
using Core.Application.Services.Notification.DI;
using Core.Application.Services.Room.DI;
using Core.API.CustomMiddlwares;
using Core.Application.Services.AdvertisementType.Injection;
using Core.Application.Services.Advertismenet.Inject;
using Core.Application.Services.Feadback.Injection;
using Core.Application.Services.Hotel.Injection;
using Core.Application.Services.Staff.Incident.DI;
using Core.Application.Services.Staff.Sentiments.Injection;
using Core.Application.Services.Staff.StaffSupport.DI;
using Core.Application.Services.Staff.StaffSupportResponse.DI;
using Core.Application.Services.Promo.Startup;
using Csi.VoicePack;
using Core.API.Fillters;
using Core.Persistance.PtmsCsi;
using Core.Persistance.MailServices;
using Core.Persistance.BackgroundServices;
using Domain.Core.Data;
using Domain.Core.Interfaces.AbstractInterface;
using Domain.Core.Interfaces.UniteOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<SetHttpStatusCodeFilter>();
}).AddControllersAsServices();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<GuestSideDb>(options =>
{
    options.UseSqlServer(!builder.Environment.IsProduction()? builder.Configuration.GetSection("connectionTest:CSICOnnect").Value: builder.Configuration.GetConnectionString("CSICOnnect"));
});

builder.Services.AddHttpClient<CsiVoicePack>(i => i.BaseAddress = new Uri("http://api.logixplore.com:3333/"));

builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(2044);
});

builder.Services.AddHostedService<NotifyUsersService>();
builder.Services.AddHostedService<ItemMonitoring>();
builder.Services.AddHostedService<PromoCodeMonitoring>();
builder.Services.AddHostedService<TaskDeadlineMonitor>();
builder.Services.AddHostedService<DailyStatisticWorker>();
builder.Services.AddHostedService<TaskReassignmentWorker>();
builder.Services.AddHostedService<IncidentRiskClassifierWorker>();
builder.Services.AddHostedService<StaleCartCleanerWorker>();
builder.Services.AddHostedService<RoomStatusAutoResetWorker>();
builder.Services.AddHostedService<AutoTaskAssignerWorker>();
builder.Services.AddHostedService<GuestCheckOutFinalizerWorker>();
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
        c.OperationFilter<FileUploadOperationFilter>();
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

builder.Services.AddDistributedMemoryCache();

builder.Services.AddRedisCash("127.0.0.1" ?? throw new ArgumentNullException("Redis Key Is not defined"));

builder.Services.InjectAdvertisment();
builder.Services.AddAdvertisementType();
builder.Services.InjectFeadbacks();

builder.Services.InjectGuest();

builder.Services.InjectHotel();
builder.Services.InjectLocation();

builder.Services.InjectItemCategory();
builder.Services.InjectItem();

builder.Services.AddLanguagePack();

builder.Services.InjectLog();
builder.Services.ActiveTaskLogs();
builder.Services.ActiveStaffIncident();

builder.Services.ActiveStaffInfoAboutRanOutItems();

builder.Services.InjectNotification();
builder.Services.InjectGuestNotification();
builder.Services.InjectStaffNotification();
builder.Services.ActivatePromoCode();
builder.Services.InjectItemCategoryToStaffCategory();
builder.Services.ActiveStaffSentiments();
builder.Services.ActiveStaffSupport();
builder.Services.ActiveStaffSupportResponse();
builder.Services.InjectPaymentOption();
builder.Services.AddScoped<ITemplateGatewayService, TemplateGatewayService>();
builder.Services.InjectRestaurantOrderPaymen();
builder.Services.AddScoped<SmtpService>();
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

builder.Services.InjectTaskItem();

builder.Services.InjectCart();

builder.Services.InjectTaskStatus();

builder.Services.InjectTasks();

builder.Services.AddScoped<IUniteOfWork, UniteOfWorkRepository>();

builder.Services.AddGuestActiveLanguage();

builder.Services.InjectGuestStatus();

builder.Services.InjectAudioResponse();

builder.Services.InjectAudioResponseCategory();

builder.Services.IncidentTypeDI();

builder.Services.IncidentTypeToStaffCategoryDI();
//builder.Logging.ClearProviders();
//builder.Services.InjectSeriLog();

builder.Services.AddScoped(typeof(IAdditionalFeaturesRepository<>), typeof(AdditionalFeaturesRepository<>));

var app = builder.Build();
    app.UseStaticFiles();

    app.UseSwagger();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Api V1");
        options.RoutePrefix = "swagger";
        options.InjectStylesheet("CustomJs/swagger-custom.css");
        options.InjectJavascript("/swagger-custom.js");
    });

app.UseMiddleware<TenantMiddleware>();
app.UseMiddleware<TranslationMiddleware>();
app.UseMiddleware<CashingMiddlwares>();
app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseMiddleware<RequestTranslationMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
await app.RunAsync();
