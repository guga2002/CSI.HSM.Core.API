using AutoMapper;
using GuestSide.Application.DTOs.Request.Advertisment;
using GuestSide.Application.DTOs.Request.FeedBacks;
using GuestSide.Application.DTOs.Request.Guest;
using GuestSide.Application.DTOs.Request.Item;
using GuestSide.Application.DTOs.Request.LogModel;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Request.Room;
using GuestSide.Application.DTOs.Request.Staff;
using GuestSide.Application.DTOs.Request.Task;
using GuestSide.Application.DTOs.Response.Advertisment;
using GuestSide.Application.DTOs.Response.FeedBacks;
using GuestSide.Application.DTOs.Response.Guest;
using GuestSide.Application.DTOs.Response.Item;
using GuestSide.Application.DTOs.Response.LogModel;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.DTOs.Response.Room;
using GuestSide.Application.DTOs.Response.Staff;
using GuestSide.Application.DTOs.Response.Task;
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
            CreateMap<AdvertisementTypeResponseDto, AdvertisementType>().ReverseMap();
            CreateMap<AdvertismentResponseDto,Advertisements>().ReverseMap();
            CreateMap<FeedbackResponseDto, Feedback>().ReverseMap();
            CreateMap<GuestResponseDto,Guests>().ReverseMap();
            CreateMap<CartResponseDto, Cart>().ReverseMap();
            CreateMap<ItemCategoryResponseDto,ItemCategory>().ReverseMap();
            CreateMap<ItemResponseDto,Items>().ReverseMap();
            CreateMap<LogResponseDto,Logs>().ReverseMap();
            CreateMap<GuestNotificationResponseDto,GuestNotification>().ReverseMap();
            CreateMap<NotificationResponseDto,Notifications>().ReverseMap();
            CreateMap<StafNotificationResponseDto,StaffNotification>().ReverseMap();
            CreateMap<QRCodeResponseDto,QRCode>().ReverseMap();
            CreateMap<RoomCategoryResponseDto,RoomCategory>().ReverseMap(); 
            CreateMap<RoomsResponseDto,Rooms>().ReverseMap();
            CreateMap<CartToStaffResponseDto,CartToStaff>().ReverseMap();
            CreateMap<StaffCategoryResponseDto,StaffCategory>().ReverseMap();
            CreateMap<StaffResponseDto,Staffs>().ReverseMap();
            CreateMap<TaskCategoryResponseDto,TaskCategory>().ReverseMap();
            CreateMap<TaskResponseDto,Tasks>().ReverseMap();
        }
    }
}
