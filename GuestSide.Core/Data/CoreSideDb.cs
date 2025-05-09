using Domain.Core.Entities.Advertisements;
using Domain.Core.Entities.Audio;
using Domain.Core.Entities.FeedBacks;
using Domain.Core.Entities.Guest;
using Domain.Core.Entities.Hotel;
using Domain.Core.Entities.Hotel.GeoLocation;
using Domain.Core.Entities.Item;
using Domain.Core.Entities.Language;
using Domain.Core.Entities.LogEntities;
using Domain.Core.Entities.Notification;
using Domain.Core.Entities.Payment;
using Domain.Core.Entities.Promo;
using Domain.Core.Entities.Restaurant;
using Domain.Core.Entities.Room;
using Domain.Core.Entities.Staff;
using Domain.Core.Entities.Statistic;
using Domain.Core.Entities.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Domain.Core.Data;

public class CoreSideDb : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CoreSideDb(DbContextOptions<CoreSideDb> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {

        _httpContextAccessor = httpContextAccessor;
    }

    public virtual DbSet<Advertisement> Advertisements { get; set; }

    public virtual DbSet<AdvertisementType> AdvertisementTypes { get; set; }

    public virtual DbSet<DailyStatistic> DailyStatistics { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Guests> Guests { get; set; }

    public virtual DbSet<Status> GuestStatuses { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Items> Items { get; set; }

    public virtual DbSet<ItemCategory> ItemCategories { get; set; }

    public virtual DbSet<Logs> Logs { get; set; }

    public virtual DbSet<GuestNotification> GuestNotifications { get; set; }

    public virtual DbSet<StaffNotification> StaffNotifications { get; set; }

    public virtual DbSet<Notifications> Notifications { get; set; }

    public virtual DbSet<QRCode> QrCodes { get; set; }

    public virtual DbSet<RoomCategory> RoomCategories { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<StaffCategory> StaffCategories { get; set; }

    public virtual DbSet<Staffs> Staffs { get; set; }

    public virtual DbSet<Tasks> Tasks { get; set; }

    public virtual DbSet<TasksStatus> TaskStatuses { get; set; }

    public virtual DbSet<AudioResponse> AudioResponses { get; set; }

    public virtual DbSet<AudioResponseCategory> AudioResponseCategories { get; set; }

    public virtual DbSet<LanguagePack> LanguagePacks { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<GuestActiveLanguage> GuestActiveLanguages { get; set; }

    public virtual DbSet<TaskToStaff> TaskToStaffs { get; set; }

    public virtual DbSet<RestaurantOrderPayment> PaymentMethods { get; set; }

    public virtual DbSet<Restaurants> Restaurants { get; set; }

    public virtual DbSet<RestaurantItem> RestaurantsItems { get; set; }

    public virtual DbSet<RestaurantCart> RestaurantCarts { get; set; }

    public virtual DbSet<RestaurantItemCategory> RestaurantItemCategories { get; set; }

    public virtual DbSet<PaymentOption> PaymentOptions { get; set; }

    public virtual DbSet<RestaurantItemToCart> RestaurantItemToCarts { get; set; }

    public virtual DbSet<TaskItem> TaskItems { get; set; }

    public virtual DbSet<ItemCategoryToStaffCategory> ItemCategoryToStaffCategories { get; set; }

    public virtual DbSet<StaffInfoAboutRanOutItems> StaffInfoAboutRanOutItems { get; set; }

    public virtual DbSet<StaffReserveItem> StaffReserveItems { get; set; }

    public virtual DbSet<StaffIncident> StaffIncidents { get; set; }

    public virtual DbSet<StaffSentiment> StaffSentiments { get; set; }

    public virtual DbSet<StaffSupport> StaffSupports { get; set; }

    public virtual DbSet<StaffSupportResponse> StaffSupportResponses { get; set; }

    public virtual DbSet<PromoCode> PromoCodes { get; set; }

    public virtual DbSet<TaskLogs> TaskLogs { get; set; }

    public virtual DbSet<IncidentType> IncidentTypes { get; set; }

    public virtual DbSet<IncidentTypeToStaffCategory> IncidentTypeToStaffCategories { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<VoiceRequest> VoiceRequests { get; set; }

    public virtual DbSet<IssueKeyword> IssueKeywords { get; set; }

    public virtual DbSet<ItemBehaviorType> ItemBehaviorTypes { get; set; }

    public virtual DbSet<ScheduledDelivery> ScheduledDeliveries {  get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = _httpContextAccessor.HttpContext?.Items["ConnectionString"]?.ToString();
        if (!string.IsNullOrEmpty(connectionString))
        {
            Console.WriteLine($"connection String changed:{connectionString}");
            optionsBuilder.UseSqlServer(connectionString);
        }
        else
        {
            Console.WriteLine("Default case");
            // optionsBuilder.UseSqlServer("Data Source=DESKTOP-JT3FIU7\\SQLEXPRESS;Initial Catalog=CSILopota;Integrated Security=True;TrustServerCertificate=True;");//default case
        }
    }
}
