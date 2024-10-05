using GuestSide.Application.Services.AdvertisementType;
using GuestSide.Application.Services.Advertismenet;
using GuestSide.Core.Data;
using GuestSide.Persistance.Reflections;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAdvertisementType();
builder.Services.InjectAdvertisment();
builder.Services.AddAdvertisementType();

builder.Services.AddDbContext<GuestSideDb>(
    str =>
    {
        str.UseSqlServer(builder.Configuration.GetConnectionString("CSIGuest"));
    }
);

builder.Services.AddAutoMapper(typeof(GuestSide.Application.Mapper.AutoMapper));

var interfaceAssembly = Assembly.Load("GuestSide.Core");
var implementationAssembly = Assembly.Load("GuestSide.Infrastructure");
builder.Services.AddInjectRepositories(interfaceAssembly, implementationAssembly);



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
