using Core.Core.Interfaces.Advertisement;
using Core.Core.Interfaces.Audio;
using Core.Core.Interfaces.FeedBack;
using Core.Core.Interfaces.Guest;
using Core.Core.Interfaces.Hotel;
using Core.Core.Interfaces.Item;
using Core.Core.Interfaces.Language;
using Core.Core.Interfaces.LogEntities;
using Core.Core.Interfaces.Notification;
using Core.Core.Interfaces.Restaurant;
using Core.Core.Interfaces.Restaurant.Payment;
using Core.Core.Interfaces.Room;
using Core.Core.Interfaces.Staff;
using Core.Core.Interfaces.Task;

namespace Core.Core.Interfaces.UniteOfWork;

public interface IUniteOfWork
{
    public IAdvertisementRepository AdvertisementRepository { get; }

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

    public IItemsRepository ItemRepository { get; }

    public ILanguagePackRepository LanguagePackRepository { get; }

    public ILogsRepository LogRepository { get; }

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

    public ITaskRepository TaskRepository { get; }

    public ITaskStatusRepository TaskStatusRepository { get; }

    public ITaskItemRepository TaskItem { get; }

    public IItemCategoryToStaffCategoryRepository ItemCategoryToStaffCategory { get; }

    public IIncidentTypeRepository IncidentTypeRepository { get; }

    public IIncidentTypeToStaffCategoryRepository IncidentTypeToStaffCategory { get; }

    System.Threading.Tasks.Task Savechanges(bool Track = false);

    System.Threading.Tasks.Task BeginTransaction();

    System.Threading.Tasks.Task CommitTransaction();

    System.Threading.Tasks.Task RollbackTransaction();
}
