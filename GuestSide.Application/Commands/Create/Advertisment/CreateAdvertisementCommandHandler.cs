using AutoMapper;
using GuestSide.Application.Interface;
using GuestSide.Core.Entities.Advertisements;
using GuestSide.Core.Interfaces.Advertisement;

namespace GuestSide.Application.Commands.Create.Advertisment
{
    public class CreateAdvertisementCommandHandler : ICommandHandler<CreateAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly  IMapper _mapper;

        public CreateAdvertisementCommandHandler(IAdvertisementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(CreateAdvertisementCommand command)
        {
            var advertisement = _mapper.Map<Advertisements>(command);
            await _repository.AddAsync(advertisement);
        }
    }
}
