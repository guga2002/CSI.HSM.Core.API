using Domain.Core.Data;
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
using Domain.Core.Interfaces.UniteOfWork;

namespace Core.Infrastructure.Repositories.UniteOfWork;

public class UniteOfWorkRepository : IUniteOfWork
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

    public ICommentRepository CommentRepository { get; }


    private readonly GuestSideDb _context;

    public UniteOfWorkRepository(
     IAdvertisementRepository advertisementRepository,
     IAdvertisementTypeRepository advertisementTypeRepository,
     IAudioResponseCategoryRepository audioResponseCategoryRepository,
     IAudioResponseRepository audioResponseRepository,
     IFeedbackRepository feedbackRepository,
     IGuestActiveLanguageRepository guestActiveLanguageRepository,
     IGuestRepository guestRepository,
     IStatusRepository statusRepository,
     IHotelRepository hotelRepository,
     ILocationRepository locationRepository,
     ICartRepository cartRepository,
     IItemCategoryRepository itemCategoryRepository,
     IItemsRepository itemRepository,
     ILanguagePackRepository languagePackRepository,
     ILogsRepository logRepository,
     IGuestNotificationRepository guestNotificationRepository,
     INotificationRepository notificationRepository,
     IStaffNotificationRepository staffNotificationRepository,
     IPaymentOptionRepository paymentOptionRepository,
     IRestaurantOrderPaymentRepository restaurantOrderPaymentRepository,
     IRestaunrantItemRepository restaunrantItemRepository,
     IRestaurantCartRepository restaurantCartRepository,
     IRestaurantItemCategoryRepository restaurantItemCategoryRepository,
     IRestaurantItemToCartRepository restaurantItemToCartRepository,
     IRestaurantRepository restaurantRepository,
     IQRCodeRepository qrCodeRepository,
     IRoomCategoryRepository roomCategoryRepository,
     IRoomRepository roomRepository,
     IStaffCategoryRepository staffCategoryRepository,
     IStaffRepository staffRepository,
     ITaskToStaffRepository taskToStaffRepository,
     ITaskRepository taskRepository,
     ITaskStatusRepository taskStatusRepository,
     ITaskItemRepository taskItem,
     IItemCategoryToStaffCategoryRepository itemCategoryToStaffCategory,
     IIncidentTypeRepository incidentTypeRepository,
     IIncidentTypeToStaffCategoryRepository incidentTypeToStaffCategoryRepository,
     ICommentRepository commentRepository,
     GuestSideDb Context
 )
    {
        AdvertisementRepository = advertisementRepository;
        AdvertisementTypeRepository = advertisementTypeRepository;
        AudioResponseCategoryRepository = audioResponseCategoryRepository;
        AudioResponseRepository = audioResponseRepository;
        FeedbackRepository = feedbackRepository;
        GuestActiveLanguageRepository = guestActiveLanguageRepository;
        GuestRepository = guestRepository;
        StatusRepository = statusRepository;
        HotelRepository = hotelRepository;
        LocationRepository = locationRepository;
        CartRepository = cartRepository;
        ItemCategoryRepository = itemCategoryRepository;
        ItemRepository = itemRepository;
        LanguagePackRepository = languagePackRepository;
        LogRepository = logRepository;
        GuestNotificationRepository = guestNotificationRepository;
        NotificationRepository = notificationRepository;
        StaffNotificationRepository = staffNotificationRepository;
        PaymentOptionRepository = paymentOptionRepository;
        RestaurantOrderPaymentRepository = restaurantOrderPaymentRepository;
        RestaunrantItemRepository = restaunrantItemRepository;
        RestaurantCartRepository = restaurantCartRepository;
        RestaurantItemCategoryRepository = restaurantItemCategoryRepository;
        RestaurantItemToCartRepository = restaurantItemToCartRepository;
        RestaurantRepository = restaurantRepository;
        QRCodeRepository = qrCodeRepository;
        RoomCategoryRepository = roomCategoryRepository;
        RoomRepository = roomRepository;
        StaffCategoryRepository = staffCategoryRepository;
        StaffRepository = staffRepository;
        TaskToStaffRepository = taskToStaffRepository;
        TaskRepository = taskRepository;
        TaskStatusRepository = taskStatusRepository;
        TaskItem = taskItem;
        ItemCategoryToStaffCategory = itemCategoryToStaffCategory;
        IncidentTypeRepository = incidentTypeRepository;
        IncidentTypeToStaffCategory = incidentTypeToStaffCategoryRepository;
        IncidentTypeRepository = incidentTypeRepository;
        _context = Context;
    }

    public async System.Threading.Tasks.Task BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async System.Threading.Tasks.Task CommitTransaction()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async System.Threading.Tasks.Task RollbackTransaction()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async System.Threading.Tasks.Task Savechanges(bool Track = false)
    {
        await _context.SaveChangesAsync(Track);
    }
}
