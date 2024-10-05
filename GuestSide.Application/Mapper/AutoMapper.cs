using AutoMapper;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.DTOs.FeedBacks;
using GuestSide.Application.DTOs.Item;
using GuestSide.Application.DTOs.Log;
using GuestSide.Application.DTOs.NewFolder;
using GuestSide.Application.DTOs.Notification;
using GuestSide.Application.DTOs.Room;
using GuestSide.Application.DTOs.Staff;
using GuestSide.Application.DTOs.Task;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Entities.Advertisments;
using GuestSide.Core.Entities.Feedbacks;
using GuestSide.Core.Entities.Guest;
using GuestSide.Core.Entities.Item;
using GuestSide.Core.Entities.LogEntities;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Entities.Room;
using GuestSide.Core.Entities.Staff;
using GuestSide.Core.Entities.Task;

namespace GuestSide.Application.Mapper
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<AdvertisementTypeDto, AdvertisementType>().ReverseMap();
            CreateMap<AdvertismentDto,Advertisements>().ReverseMap();
            CreateMap<FeedbackDto, Feedback>().ReverseMap();
            CreateMap<GuestDto,Guests>().ReverseMap();
            CreateMap<CartDto, Cart>().ReverseMap();
            CreateMap<ItemCategoryDto,ItemCategory>().ReverseMap();
            CreateMap<ItemDto,Items>().ReverseMap();
            CreateMap<LogDto,Logs>().ReverseMap();
            CreateMap<GuestNotificationDto,GuestNotification>().ReverseMap();
            CreateMap<NotificationDto,Notifications>().ReverseMap();
            CreateMap<StafNotificationDto,StaffNotification>().ReverseMap();
            CreateMap<QRCodeDto,QRCode>().ReverseMap();
            CreateMap<RoomCategoryDto,RoomCategory>().ReverseMap(); 
            CreateMap<RoomsDto,Rooms>().ReverseMap();
            CreateMap<CartToStaffDto,CartToStaff>().ReverseMap();
            CreateMap<StaffCategoryDto,StaffCategory>().ReverseMap();
            CreateMap<StaffDto,Staffs>().ReverseMap();
            CreateMap<TaskCategoryDto,TaskCategory>().ReverseMap();
            CreateMap<TaskDto,Tasks>().ReverseMap();
        }
    }
}
