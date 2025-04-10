using Domain.Core.Interfaces.Advertisement;
using Domain.Core.Interfaces.Audio;
using Domain.Core.Interfaces.FeedBack;
using Domain.Core.Interfaces.Guest;
using Domain.Core.Interfaces.Hotel;
using Domain.Core.Interfaces.Item;
using Domain.Core.Interfaces.Language;
using Domain.Core.Interfaces.LogInterfaces;
using Domain.Core.Interfaces.Notification;
using Domain.Core.Interfaces.Restaurant;
using Domain.Core.Interfaces.Restaurant.Payment;
using Domain.Core.Interfaces.Room;
using Domain.Core.Interfaces.Staff;
using Domain.Core.Interfaces.Task;

namespace Domain.Core.Interfaces.UniteOfWork;

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
