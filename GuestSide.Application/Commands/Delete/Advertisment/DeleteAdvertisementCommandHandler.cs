using GuestSide.Application.Interface;
using GuestSide.Core.Interfaces.Advertisement;

namespace GuestSide.Application.Commands.Delete.Advertisment
{
    public class DeleteAdvertisementCommandHandler : ICommandHandler<DeleteAdvertisementCommand>
    {
        private readonly IAdvertisementRepository _repository;

        public DeleteAdvertisementCommandHandler(IAdvertisementRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteAdvertisementCommand command)
        {
            var advertisement = await _repository.GetByIdAsync(command.Id);
            if (advertisement == null)
            {
                throw new ArgumentException("Advertisement not found");
            }

            await _repository.DeleteAsync(advertisement);
        }
    }
}
