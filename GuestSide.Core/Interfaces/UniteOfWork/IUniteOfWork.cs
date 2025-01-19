using Core.Core.Interfaces.Audio;
using Core.Core.Interfaces.Guest;
using Core.Core.Interfaces.Item;
using Core.Core.Interfaces.Language;
using Core.Core.Interfaces.Restaurant;
using Core.Core.Interfaces.Restaurant.Payment;
using GuestSide.Core.Interfaces.Advertisement;
using GuestSide.Core.Interfaces.FeedBack;
using GuestSide.Core.Interfaces.Guest;
using GuestSide.Core.Interfaces.Hotel;
using GuestSide.Core.Interfaces.Item;
using GuestSide.Core.Interfaces.LogInterfaces;
using GuestSide.Core.Interfaces.Notification;
using GuestSide.Core.Interfaces.Room;
using GuestSide.Core.Interfaces.Staff;
using GuestSide.Core.Interfaces.Task;

namespace Core.Core.Interfaces.UniteOfWork;

public interface IUniteOfWork
{
    public IAdvertisementRepository AdvertisementRepository{ get;}
    public IAdvertisementTypeRepository AdvertisementTypeRepository { get; }
    public IAudioResponseCategoryRepository AudioResponseCategoryRepository { get; }
    public IAudioResponseRepository AudioResponseRepository { get; }
    public IFeedbackRepository FeedbackRepository { get; }

    public IGuestActiveLanguageRepository GuestActiveLanguageRepository { get; }
    public IGuestRepository GuestRepository { get; }
    public IStatusRepository StatusRepository { get; }
    public IHotelRepository HotelRepository { get; }
    public ILocationRepository LocationRepository { get; }
    public ICartRepository CartRepository { get; }
    public IItemCategoryRepository ItemCategoryRepository { get; }
    public IItemRepository ItemRepository { get; }
    public IOrderableItemRepository OrderableItemRepository { get; }
    public ILanguagePackRepository LanguagePackRepository { get; }

    public ILogRepository LogRepository { get; }
    public IGuestNotificationRepository GuestNotificationRepository { get; }
    public INotificationRepository NotificationRepository { get; }
    public IStaffNotificationRepository StaffNotificationRepository { get; }
    public IPaymentOptionRepository PaymentOptionRepository { get; }
    public IRestaurantOrderPaymentRepository RestaurantOrderPaymentRepository { get; }


    public IRestaunrantItemRepository RestaunrantItemRepository { get; }
    public IRestaurantCartRepository RestaurantCartRepository { get; }
    public IRestaurantItemCategoryRepository RestaurantItemCategoryRepository { get; }
    public IRestaurantItemToCartRepository RestaurantItemToCartRepository { get; }
    public IRestaurantRepository RestaurantRepository { get; }
    public IQRCodeRepository QRCodeRepository { get; }

    public IRoomCategoryRepository RoomCategoryRepository { get; }
    public IRoomRepository RoomRepository { get; }
    public IStaffCategoryRepository StaffCategoryRepository { get; }
    public IStaffRepository StaffRepository { get; }
    public ITaskToStaffRepository TaskToStaffRepository { get; }
    public ITaskCategoryRepository TaskCategoryRepository { get; }

    public ITaskRepository TaskRepository { get; }
    public ITaskStatusRepository TaskStatusRepository { get; }

    Task Savechanges(bool Track = false);

    Task BeginTransaction();

    Task CommitTransaction();

    Task RollbackTransaction();
}
