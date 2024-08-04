using AutoMapper;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.Advertisement;

namespace GuestSide.Application.Queries.GetEntity.Advertiment
{
    public class GetAdvertisementByIdQueryHandler : IQueryHandler<GetAdvertisementByIdQuery, AdvertismentDto>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly IMapper _mapper;

        public GetAdvertisementByIdQueryHandler(IAdvertisementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AdvertismentDto> Handle(GetAdvertisementByIdQuery query)
        {
            var advertisement = await _repository.GetByIdAsync(query.Id);
            if (advertisement == null)
            {
                throw new ArgumentException("Advertisement not found");
            }
            return _mapper.Map<AdvertismentDto>(advertisement);
        }
    }
}
