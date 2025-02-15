using AutoMapper;
using Core.Application.DTOs.Request.Item;
using Core.Application.DTOs.Response.Item;
using Core.Application.Interface.Item;
using Core.Core.Entities.Item;
using Core.Core.Interfaces.AbstractInterface;
using Core.Core.Interfaces.Item;
using Microsoft.Extensions.Logging;

namespace Core.Application.Services.Item.Services
{
    public class CartService : GenericService<CartDto, CartResponseDto, long, Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CartService> _logger;

        public CartService(
            IMapper mapper,
            ICartRepository cartRepository,
            ILogger<CartService> logger,
            IGenericRepository<Cart> repository,
            IAdditionalFeaturesRepository<Cart> additionalFeatures)
            : base(mapper, repository, logger, additionalFeatures)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
            _logger = logger;
        }

        private void ValidatePositiveId(long id, string paramName)
        {
            if (id <= 0)
            {
                _logger.LogWarning("{ParameterName} must be a positive number.", paramName);
                throw new ArgumentException($"{paramName} must be greater than zero.", paramName);
            }
        }

        private void ValidateQuantity(int quantity)
        {
            if (quantity < 0)
            {
                _logger.LogWarning("Quantity must be non-negative.");
                throw new ArgumentException("Quantity must be a non-negative value.");
            }
        }

        public async Task<bool> ClearCart(long cartId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(cartId, nameof(cartId));

            return await _cartRepository.ClearCart(cartId);
        }

        public async Task<CartResponseDto?> CartSummary(long cartId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(cartId, nameof(cartId));

            var cart = await _cartRepository.CartSymmary(cartId);
            return cart is null ? null : _mapper.Map<CartResponseDto>(cart);
        }

        public async Task<CartResponseDto> RemoveItemFromCart(long cartId, long itemId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(cartId, nameof(cartId));
            ValidatePositiveId(itemId, nameof(itemId));

            var cart = await _cartRepository.RemoveItemFromCart(cartId, itemId);
            return _mapper.Map<CartResponseDto>(cart);
        }

        public async Task<List<ItemResponseDto>> ValidateCartItemsAvailability(long cartId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(cartId, nameof(cartId));

            var items = await _cartRepository.ValidateCartItemsAvailability(cartId);
            return _mapper.Map<List<ItemResponseDto>>(items);
        }

        public async Task<CartResponseDto> UpdateItemQuantityInCart(long cartId, long itemId, int newQuantity, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(cartId, nameof(cartId));
            ValidatePositiveId(itemId, nameof(itemId));
            ValidateQuantity(newQuantity);

            var cart = await _cartRepository.UpdateItemQuantityInCart(cartId, itemId, newQuantity);
            return _mapper.Map<CartResponseDto>(cart);
        }

        public async Task<IEnumerable<CartResponseDto>> GetCartByGuestId(long guestId, bool status, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var carts = await _cartRepository.GetCartByGuestId(guestId, status);
            return _mapper.Map<IEnumerable<CartResponseDto>>(carts);
        }

        public async Task<CartResponseDto?> GetLatestActiveCartForGuestAsync(long guestId, CancellationToken cancellationToken = default)
        {
            ValidatePositiveId(guestId, nameof(guestId));

            var cart = await _cartRepository.GetLatestActiveCartForGuestAsync(guestId);
            return cart is null ? null : _mapper.Map<CartResponseDto>(cart);
        }
    }
}
