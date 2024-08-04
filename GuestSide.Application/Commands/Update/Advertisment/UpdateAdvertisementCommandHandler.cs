using AutoMapper;
using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.Advertisement;

namespace GuestSide.Application.Commands.Update.Advertisment
{
    public class UpdateAdvertisementCommandHandler : ICommandHandler<UpdateAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _repository;
        private readonly IMapper _mapper;

        public UpdateAdvertisementCommandHandler(IAdvertisementRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateAdvertisementCommand command)
        {
            var advertisement = await _repository.GetByIdAsync(command.Id);
            if (advertisement == null)
            {
                throw new ArgumentException("Advertisement not found");
            }

            _mapper.Map(command, advertisement);
            await _repository.UpdateAsync(advertisement);
        }
    }
}
