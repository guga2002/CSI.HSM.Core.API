﻿// <auto-generated />
using System;
using GuestSide.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuestSide.Core.Migrations
{
    [DbContext(typeof(GuestSideDb))]
    partial class GuestSideDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GuestSide.Core.Entities.Advertisements.Advertisement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AdvertisementTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("MediaUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdvertisementTypeId");

                    b.ToTable("Advertisements");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Advertisments.AdvertisementType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdvertisementTypes");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Feedbacks.Feedback", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FeedbackDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<long>("TasksId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TasksId");

                    b.ToTable("Feedbacks");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Guest.Guests", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CheckInDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("CheckOutDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.Cart", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("GuestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.ItemCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CategoryName");

                    b.HasKey("Id");

                    b.ToTable("ItemCategories");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.Items", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ItemCategoryId")
                        .HasColumnType("bigint");

                    b.Property<byte>("ItemCount")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ItemName");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ItemCategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.LogEntities.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Exception")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Notification.GuestNotification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("GuestId")
                        .HasColumnType("bigint");

                    b.Property<long>("NotificationId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("GuestId");

                    b.HasIndex("NotificationId");

                    b.ToTable("GuestNotifications");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Notification.Notifications", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NotificationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Notification.StaffNotification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("NotificationId")
                        .HasColumnType("bigint");

                    b.Property<long>("StaffId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.HasIndex("StaffId");

                    b.ToTable("StaffNotifications");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Room.QRCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("GeneratedDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RoomId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("RoomId")
                        .IsUnique();

                    b.ToTable("QRCodes");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Room.RoomCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoomCategories");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Room.Rooms", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("Floor")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<long>("RoomCategoryId")
                        .HasColumnType("bigint");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomCategoryId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Staff.CartToStaff", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("StaffId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CartId")
                        .IsUnique();

                    b.HasIndex("StaffId");

                    b.HasIndex("StatusId");

                    b.ToTable("CartToStaffs");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Staff.StaffCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StaffCategories");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Staff.Staffs", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StaffCategoryId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("StaffCategoryId");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Task.TaskCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TaskCategories");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Task.Tasks", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("CartId")
                        .HasColumnType("bigint");

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ItemId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ItemId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Task.TasksStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NameOfStatus");

                    b.HasKey("Id");

                    b.ToTable("TaskStatus");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Advertisements.Advertisement", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Advertisments.AdvertisementType", "AdvertisementType")
                        .WithMany("Advertisements")
                        .HasForeignKey("AdvertisementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AdvertisementType");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Feedbacks.Feedback", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Task.Tasks", "Task")
                        .WithMany("Feedbacks")
                        .HasForeignKey("TasksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Task");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Guest.Guests", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Room.Rooms", "Room")
                        .WithMany("Guests")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.Cart", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Guest.Guests", "Guest")
                        .WithMany("Tasks")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.Items", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Item.ItemCategory", "ItemCategory")
                        .WithMany("Item")
                        .HasForeignKey("ItemCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategory");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Notification.GuestNotification", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Guest.Guests", "Guest")
                        .WithMany("GuestNotifications")
                        .HasForeignKey("GuestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuestSide.Core.Entities.Notification.Notifications", "Notifications")
                        .WithMany("GuestNotifications")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guest");

                    b.Navigation("Notifications");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Notification.StaffNotification", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Notification.Notifications", "Notifications")
                        .WithMany("StaffNotifications")
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuestSide.Core.Entities.Staff.Staffs", "Staff")
                        .WithMany("StaffNotifications")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Notifications");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Room.QRCode", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Room.Rooms", "Room")
                        .WithOne("QRCode")
                        .HasForeignKey("GuestSide.Core.Entities.Room.QRCode", "RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Room.Rooms", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Room.RoomCategory", "RoomCategory")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomCategory");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Staff.CartToStaff", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Item.Cart", "Cart")
                        .WithOne("CartToStaff")
                        .HasForeignKey("GuestSide.Core.Entities.Staff.CartToStaff", "CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuestSide.Core.Entities.Staff.Staffs", "Staff")
                        .WithMany("CartToStaffs")
                        .HasForeignKey("StaffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuestSide.Core.Entities.Task.TasksStatus", "Status")
                        .WithMany("CartToStaffs")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Staff");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Staff.Staffs", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Staff.StaffCategory", "StaffCategory")
                        .WithMany("Staff")
                        .HasForeignKey("StaffCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StaffCategory");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Task.Tasks", b =>
                {
                    b.HasOne("GuestSide.Core.Entities.Item.Cart", "Cart")
                        .WithMany("Tasks")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuestSide.Core.Entities.Task.TaskCategory", "Category")
                        .WithMany("Tasks")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuestSide.Core.Entities.Item.Items", "Item")
                        .WithMany("Tasks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Category");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Advertisments.AdvertisementType", b =>
                {
                    b.Navigation("Advertisements");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Guest.Guests", b =>
                {
                    b.Navigation("GuestNotifications");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.Cart", b =>
                {
                    b.Navigation("CartToStaff")
                        .IsRequired();

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.ItemCategory", b =>
                {
                    b.Navigation("Item");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Item.Items", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Notification.Notifications", b =>
                {
                    b.Navigation("GuestNotifications");

                    b.Navigation("StaffNotifications");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Room.RoomCategory", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Room.Rooms", b =>
                {
                    b.Navigation("Guests");

                    b.Navigation("QRCode")
                        .IsRequired();
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Staff.StaffCategory", b =>
                {
                    b.Navigation("Staff");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Staff.Staffs", b =>
                {
                    b.Navigation("CartToStaffs");

                    b.Navigation("StaffNotifications");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Task.TaskCategory", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Task.Tasks", b =>
                {
                    b.Navigation("Feedbacks");
                });

            modelBuilder.Entity("GuestSide.Core.Entities.Task.TasksStatus", b =>
                {
                    b.Navigation("CartToStaffs");
                });
#pragma warning restore 612, 618
        }
    }
}
