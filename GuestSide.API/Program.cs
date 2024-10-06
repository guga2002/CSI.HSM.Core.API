using GuestSide.Application.Services.AdvertisementType;
using GuestSide.Application.Services.Advertismenet;
using GuestSide.Application.Services.Feadback;
using GuestSide.Application.Services.Staff.Cart;
using GuestSide.Core.Data;
using GuestSide.Persistance.Reflections;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CustomMiddlwares>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
