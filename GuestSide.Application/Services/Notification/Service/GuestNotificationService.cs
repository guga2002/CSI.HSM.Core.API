using AutoMapper;
using Core.Application.DTOs.Request.Notification;
using Core.Application.DTOs.Response.Notification;
using Core.Application.Interface.Notification;
using Core.Application.Services;
using Core.Core.Entities.Notification;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Notification;
using Core.Infrastructure.Repositories.AbstractRepository;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Notification.Service;

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
        _map = mapper;
    }

    public async Task<IEnumerable<GuestNotificationResponseDto>> GetNotificationsByGuestId(long GuestId)
    {
        var res = await _guestNotificationRepository.GetNotificationsByGuestId(GuestId);
        if (res is not null)
        {
            return _map.Map<IEnumerable<GuestNotificationResponseDto>>(res);
        }
        return null;
    }

    public async Task<GuestNotificationResponseDto> MarkGuestNotificationAsRead(long GuestId, long NotificationId, bool unread = false)
    {
        var res = await _guestNotificationRepository.MarkGuestNotificationAsRead(GuestId, NotificationId, unread);
        if (res is not null)
        {
            return _map.Map<GuestNotificationResponseDto>(res);
        }
        return null;
    }
}
