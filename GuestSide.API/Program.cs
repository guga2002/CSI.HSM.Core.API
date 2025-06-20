using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Core.Application.Services.Hotel.Injection;
using Core.Application.Services.LogService.DI;
using Core.Application.Services.Room.DI;
using Core.Application.Services.Staff.Category.DI;
using Core.Application.Services.Staff.Incident.DI;
using Core.Application.Services.Restaurant.DI;
using Core.Application.Services.Audio.Injection;
using Core.Application.Services.Notification.DI;
using Core.Application.Services.Staff.StaffSupportResponse.DI;
using Core.Application.Services.Promo.Startup;
using Core.Application.Services.Staff.Sentiments.Injection;
using Core.Application.Services.Feadback.Injection;
using Core.Application.Services.Item.DI;
using Core.Application.Services.Payment.PaymentOption.DI;
using Core.Application.Services.Language.Di;
using Core.Application.Services.Task.Task.DI;
using Core.Application.Services.Staff.Staff.DI;
using Core.Application.Services.Guest.Injection;
using Core.Application.Services.Staff.Cart.DI;
using Core.Application.Services.Payment.RestaurantOrderPayment.DI;
using Core.Application.Services.Task.TaskLog.Startup;
using Core.Application.Services.Staff.StaffSupport.DI;
using Core.Application.Services.Task.Status.DI;
using Core.Application.Services.AdvertisementType.Injection;
using Core.Application.Services.Contacts.Injection;
using Core.Application.Services.Task.Comments.DI;
using Core.Application.Services.Advertismenet.Inject;
using Common.Data.Data;
using Common.Data.Interfaces.UniteOfWork;
using Common.Data.Interfaces.AbstractInterface;
using Common.Data.Repositories.UniteOfWork;
using Common.Data.Repositories.AbstractRepository;
using Generic.API.Injections;
using Generic.API.ServiceProvider.Interface;
using Generic.API.ServiceProvider.Service;
using Microsoft.Data.SqlClient;
using System.Data;
using Generic.API.Filters;
using Generic.API.Middlwares;
using Serilog.Events;
using Serilog;


//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//    .MinimumLevel.Override("System", LogEventLevel.Warning)
//    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
//    .Enrich.FromLogContext()
//    .WriteTo.Console()
//    .WriteTo.Seq("http://api.logixplore.com:5341", apiKey: "v6SEypIug5QHmu0hUgsS")
//    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
 .AddControllersAsServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontendLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials();
    });
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHttpContextAccessor();

builder.Services.ActiveShearedServices(builder.Configuration);

builder.Services.AddScoped<ICoreServiceProvider,CoreServiceProvider>();


builder.Services.AddDbContext<CoreSideDb>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CSICOnnect"));
});


if (builder.Environment.IsProduction())
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(2044, listenOptions =>
        {
            listenOptions.UseHttps("C:\\certs\\SSLFORCSI.pfx", "Tabaxmela123#");
        });
        options.ListenAnyIP(2045);
    });
}

builder.Services.AddScoped<IDbConnection>(sp =>
{
    var context = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;
    var connStr = context?.Items["HotelDbConnection"] as SqlConnection;
    if (connStr is not null)
        return connStr;
    throw new InvalidOperationException("Database connection string not found in HttpContext.Items.");
});


builder.Services.ActivateCashing();

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
builder.Services.InjectTaskItem();
builder.Services.InjectCart();
builder.Services.InjectTaskStatus();
builder.Services.InjectTasks();
builder.Services.InjectContact();
builder.Services.InjectContactsStaffType();
builder.Services.InjectComment();
builder.Services.AddScoped<IUniteOfWork, UniteOfWorkRepository>();
builder.Services.AddGuestActiveLanguage();
builder.Services.InjectGuestStatus();
builder.Services.InjectAudioResponse();
builder.Services.InjectAudioResponseCategory();
builder.Services.IncidentTypeDI();
builder.Services.IncidentTypeToStaffCategoryDI();
builder.Services.AddMemoryCache();
builder.Services.AddScoped(typeof(IAdditionalFeaturesRepository<>), typeof(AdditionalFeaturesRepository<>));

var app = builder.Build();

app.UseCors("AllowFrontendLocalhost");
//app.UseMiddleware<SwaggerAccessMiddleware>();
app.UseMiddleware<TenantDbConnectionMiddleware>();
//app.UseMiddleware<CachingMiddleware>();
//app.UseMiddleware<RequestTranslationMiddleware>();
//app.UseMiddleware<ProductionGuardMiddleware>();
app.UseStaticFiles();
app.UseSwagger();

app.UseSwaggerUI(options =>
{
    //options.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Api V1");
    //options.RoutePrefix = "swagger";
   // options.InjectStylesheet("/swagger-custom.css");

   // options.InjectJavascript("/swagger-voice-search.js");
    //options.InjectJavascript("/swagger-custom.js");
});

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
