using GuestSide.Application.Services.AdvertisementType;
using GuestSide.Application.Services.Advertismenet;
using GuestSide.Application.Services.Feadback;
using GuestSide.Application.Services.Staff.Cart;
using GuestSide.Core.Data;
using Microsoft.EntityFrameworkCore;
using GuestSide.Application.Services.Staff.Category;
using GuestSide.Application.Services.Task.Category;
using GuestSide.Application.Services.Task.Status;
using GuestSide.Application.Services.Staff.Staf;
using GuestSide.API.CustomMiddlwares;
using GuestSide.Application.Services.Guest;
using GuestSide.Application.Services.Item.DI;
using GuestSide.Application.Services.LogService;
using GuestSide.Application.Services.Notification.DI;
using GuestSide.Application.Services.Room.DI;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GuestSide.Application.Services.Task.Task;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        //builder.Services.AddAdvertisementType();

        //builder.Services.AddAdvertisementType();

        builder.Services.AddDbContext<GuestSideDb>(
            str =>
            {
                str.UseSqlServer(builder.Configuration.GetConnectionString("CSICOnnect"));
            }
        );

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
        });



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

        builder.Services.AddAutoMapper(typeof(GuestSide.Application.Mapper.AutoMapper));

        builder.Services.AddLogging(config =>
        {
            config.AddConsole();
            config.AddDebug();
        });


        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core.Api V1");
            });
        }
        app.UseMiddleware<CustomMiddlwares>();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}