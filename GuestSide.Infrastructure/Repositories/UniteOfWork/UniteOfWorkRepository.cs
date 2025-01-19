using Core.Core.Interfaces.Audio;
using Core.Core.Interfaces.Guest;
using Core.Core.Interfaces.Item;
using Core.Core.Interfaces.Language;
using Core.Core.Interfaces.Restaurant;
using Core.Core.Interfaces.Restaurant.Payment;
using Core.Core.Interfaces.UniteOfWork;
using GuestSide.Core.Data;
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
     IItemRepository itemRepository,
     IOrderableItemRepository orderableItemRepository,
     ILanguagePackRepository languagePackRepository,
     ILogRepository logRepository,
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
     ITaskCategoryRepository taskCategoryRepository,
     ITaskRepository taskRepository,
     ITaskStatusRepository taskStatusRepository,
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
        OrderableItemRepository = orderableItemRepository;
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
        TaskCategoryRepository = taskCategoryRepository;
        TaskRepository = taskRepository;
        TaskStatusRepository = taskStatusRepository;
        _context = Context;
    }

    public async Task BeginTransaction()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransaction()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public async Task Savechanges(bool Track = false)
    {
        await _context.SaveChangesAsync(Track);
    }
}
