using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Entities.Advertisments;
using GuestSide.Core.Entities.Audio;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Entities.Task;
using Microsoft.EntityFrameworkCore;

namespace GuestSide.Core.Data
{
    public class GuestSideDb : DbContext
    {
        public GuestSideDb(DbContextOptions<GuestSideDb> options) : base(options) { }

        public virtual DbSet<Advertisements> Advertisements { get; set; }

        public virtual DbSet<AdvertisementType> AdvertisementTypes { get; set; }

        public virtual DbSet<Feedback> Feedbacks { get; set; }

        public virtual DbSet<Guests> Guests { get; set; }

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

        public virtual DbSet<TaskCategory> TaskCategories { get; set; }

        public virtual DbSet<Tasks> Tasks { get; set; }

        public virtual DbSet<TasksStatus> TaskStatuses { get; set; }

        public virtual DbSet<AudioResponse> AudioResponses { get; set; }

        public virtual DbSet<AudioResponseCategory> AudioResponseCategories { get; set; }

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

    }
}
