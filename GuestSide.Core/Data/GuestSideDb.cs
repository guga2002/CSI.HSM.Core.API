using Core.Core.Entities.Advertisements;
using Core.Core.Entities.Audio;
using Core.Core.Entities.FeedBacks;
using Core.Core.Entities.Guest;
using Core.Core.Entities.Hotel;
using Core.Core.Entities.Hotel.GeoLocation;
using Core.Core.Entities.Item;
using Core.Core.Entities.Language;
using Core.Core.Entities.LogEntities;
using Core.Core.Entities.Notification;
using Core.Core.Entities.Payment;
using Core.Core.Entities.Restaurant;
using Core.Core.Entities.Room;
using Core.Core.Entities.Staff;
using Core.Core.Entities.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Core.Core.Data;

public class GuestSideDb : DbContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public GuestSideDb(DbContextOptions<GuestSideDb> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {

        _httpContextAccessor = httpContextAccessor;
    }

    public virtual DbSet<Advertisements> Advertisements { get; set; }
    public virtual DbSet<AdvertisementType> AdvertisementTypes { get; set; }
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
    public virtual DbSet<QRCode> QRCodes { get; set; }
    public virtual DbSet<RoomCategory> RoomCategories { get; set; }
    public virtual DbSet<Rooms> Rooms { get; set; }
    public virtual DbSet<StaffCategory> StaffCategories { get; set; }
    public virtual DbSet<Staffs> Staffs { get; set; }
    public virtual DbSet<Tasks> Tasks { get; set; }
    public virtual DbSet<TasksStatus> TaskStatuses { get; set; }
    public virtual DbSet<AudioResponse> AudioResponses { get; set; }
    public virtual DbSet<AudioResponseCategory> AudioResponseCategories { get; set; }
    public virtual DbSet<LanguagePack> LanguagePacks { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<Hotel> Hotels { get; set; }
    public virtual DbSet<GuestActiveLanguage> GuestActiveLanguage { get; set; }
    public virtual DbSet<TaskToStaff> TaskToStaffs { get; set; }
    public virtual DbSet<RestaurantOrderPayment> PaymentMethods { get; set; }
    public virtual DbSet<Restaurants> Restaurants { get; set; }
    public virtual DbSet<RestaunrantItem> RestaunrantItems { get; set; }
    public virtual DbSet<RestaurantCart> RestaurantCarts { get; set; }
    public virtual DbSet<RestaurantItemCategory> RestaurantItemCategories { get; set; }
    public virtual DbSet<PaymentOption> PaymentOptions { get; set; }
    public virtual DbSet<RestaurantItemToCart> RestaurantItemToCarts { get; set; }
    public virtual DbSet<TaskItem> TaskItems { get; set; }
    public virtual DbSet<ItemCategoryToStaffCategory> ItemCategoryToStaffCategories { get; set; }


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

    public async Task<Tasks> GetTaskByCartId(long CardId)
    {
        CreateProcedure();
        var res = await Database.SqlQueryRaw<Tasks>("EXEC [dbo].[GetTaskByCartId] @CardId", CardId).FirstOrDefaultAsync();
        return res ?? throw new ArgumentNullException("No data exist!");
    }

    private void CreateProcedure()
    {
        var sql = @"
            IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.ROUTINES 
               WHERE ROUTINE_TYPE = 'PROCEDURE' 
               AND ROUTINE_NAME = 'GetTaskByCartId')
            BEGIN
            EXEC('
             CREATE PROCEDURE [dbo].[GetTaskByCartId]
            @CardId INT
            AS
            BEGIN
            SELECT * FROM [dbo].[Tasks] WHERE [CartId]= @CardId
            END
            ')
            END";
        Database.ExecuteSqlRaw(sql);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hotel>()
            .HasOne(l => l.LanguagePack)
            .WithMany()
            .HasForeignKey(l => l.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Advertisements>()
            .HasOne(l => l.languagePack)
            .WithMany()
            .HasForeignKey(l => l.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<AdvertisementType>()
            .HasOne(l => l.languagePack)
            .WithMany()
            .HasForeignKey(l => l.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<AudioResponse>()
            .HasOne(l => l.Language)
            .WithMany()
            .HasForeignKey(l => l.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Guests>()
            .HasOne(l => l.LanguagePack)
            .WithMany()
            .HasForeignKey(l => l.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<Status>()
            .HasOne(l => l.languagePack)
            .WithMany()
            .HasForeignKey(l => l.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<Cart>()
         .HasOne(l => l.language)
         .WithMany()
         .HasForeignKey(l => l.LanguageId)
         .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ItemCategory>()
       .HasOne(l => l.language)
       .WithMany()
       .HasForeignKey(l => l.LanguageId)
       .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Items>()
      .HasOne(l => l.LanguagePack)
      .WithMany()
      .HasForeignKey(l => l.LanguageId)
      .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notifications>()
      .HasOne(l => l.languagePack)
      .WithMany()
      .HasForeignKey(l => l.LanguageId)
      .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RoomCategory>()
    .HasOne(l => l.languagePack)
    .WithMany()
    .HasForeignKey(l => l.LanguageId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Rooms>()
      .HasOne(l => l.languagePack)
      .WithMany()
      .HasForeignKey(l => l.LanguageId)
      .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Tasks>()
    .HasOne(l => l.LanguagePack)
    .WithMany()
    .HasForeignKey(l => l.LanguageId)
    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TasksStatus>()
      .HasOne(l => l.languagePack)
      .WithMany()
      .HasForeignKey(l => l.LanguageId)
      .OnDelete(DeleteBehavior.Restrict);
    }
}
