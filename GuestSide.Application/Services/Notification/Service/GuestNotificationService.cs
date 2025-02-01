using AutoMapper;
using Core.Core.Interfaces.AbstractInterface;
using Core.Infrastructure.Repositories.AbstractRepository;
using GuestSide.Application.DTOs.Request.Notification;
using GuestSide.Application.DTOs.Response.Notification;
using GuestSide.Application.Interface.Notification;
using GuestSide.Core.Entities.Notification;
using GuestSide.Core.Interfaces.AbstractInterface;
using GuestSide.Core.Interfaces.Notification;
using Microsoft.Extensions.Logging;

namespace GuestSide.Application.Services.Notification.Service;

public class GuestNotificationService : GenericService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>, IGuestNotificationService
{
    private readonly IGuestNotificationRepository _guestNotificationRepository;
    private readonly IMapper _map;
    public GuestNotificationService(IMapper mapper, 
        IGenericRepository<GuestNotification> repository,
        ILogger<GenericService<GuestNotificationDto, GuestNotificationResponseDto, long, GuestNotification>> logger,
        IGuestNotificationRepository guestNotificationRepository,
        IAdditionalFeaturesRepository<GuestNotification> additioalFeatures) : base(mapper, repository, logger, additioalFeatures)
    {
        _guestNotificationRepository = guestNotificationRepository;
        _map=mapper;
    }

    public async Task<IEnumerable<GuestNotificationResponseDto>> GetNotificationsByGuestId(long GuestId)
    {
        var res = await _guestNotificationRepository.GetNotificationsByGuestId(GuestId);
        if(res is not null)
        {
            return _map.Map<IEnumerable<GuestNotificationResponseDto>>(res);
        }
        return null;
    }

    public async Task<GuestNotificationResponseDto> MarkGuestNotificationAsRead(long GuestId, long NotificationId, bool unread = false)
    {
        var res = await _guestNotificationRepository.MarkGuestNotificationAsRead(GuestId,NotificationId,unread);
        if (res is not null)
        {
            return _map.Map<GuestNotificationResponseDto>(res);
        }
        return null;
    }
}
