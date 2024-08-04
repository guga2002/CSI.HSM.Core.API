using AutoMapper;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.Advertisement;

namespace GuestSide.Application.Queries.ListEntities.Advertisment
{
    public class GetAllAdvertisementsQueryHandler : IQueryHandler<GetAllAdvertisementsQuery, IEnumerable<AdvertismentDto>>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly IMapper _mapper;

        public GetAllAdvertisementsQueryHandler(IAdvertisementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AdvertismentDto>> Handle(GetAllAdvertisementsQuery query)
        {
            var advertisements = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AdvertismentDto>>(advertisements);
        }
    }
}
