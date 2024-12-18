using Core.Core.Entities.Guest;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Entities.Advertisments;
using GuestSide.Core.Entities.Audio;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Hotel;
using GuestSide.Core.Entities.Hotel.GeoLocation;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.Language;
using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Entities.Task;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Core.Data
{
    public class GuestSideDb : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public GuestSideDb(DbContextOptions<GuestSideDb> options, IHttpContextAccessor httpContextAccessor) : base(options) {

            _httpContextAccessor = httpContextAccessor;
        }

        public virtual DbSet<Advertisements> Advertisements { get; set; }

        public virtual DbSet<AdvertisementType> AdvertisementTypes { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Guests> Guests { get; set; }

        public virtual DbSet<Status> GuestStatuses { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Items> Items { get; set; }

        public virtual DbSet<OrderableItem> OrderableItems { get; set; }

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

        public virtual DbSet<TaskCategory> TaskCategories { get; set; }

        public virtual DbSet<Tasks> Tasks { get; set; }

        public virtual DbSet<TasksStatus> TaskStatuses { get; set; }

        public virtual DbSet<AudioResponse> AudioResponses { get; set; }

        public virtual DbSet<AudioResponseCategory> AudioResponseCategories { get; set; }
        public virtual DbSet<LanguagePack> LanguagePacks { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<GuestActiveLanguage> GuestActiveLanguage { get; set; }

        public virtual DbSet<TaskToStaff> TaskToStaffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = _httpContextAccessor.HttpContext?.Items["ConnectionString"]?.ToString();
            if (!string.IsNullOrEmpty(connectionString))
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                throw new InvalidOperationException("Connection string not found.");
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
                .HasOne(l => l.languagePack)
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
                .HasOne(l => l.languagePack)
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
          .HasOne(l => l.language)
          .WithMany()
          .HasForeignKey(l => l.LanguageId)
          .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderableItem>()
          .HasOne(l => l.language)
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

            modelBuilder.Entity<TaskCategory>()
       .HasOne(l => l.languagePack)
       .WithMany()
       .HasForeignKey(l => l.LanguageId)
       .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tasks>()
        .HasOne(l => l.languagePack)
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
}
