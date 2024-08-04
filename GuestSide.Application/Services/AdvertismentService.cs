using AutoMapper;
using FluentValidation;
using GuestSide.Application.Commands.Create.Advertisment;
using GuestSide.Application.Commands.Delete.Advertisment;
using GuestSide.Application.Commands.Update.Advertisment;
using GuestSide.Application.DTOs.Advertisment;
using GuestSide.Application.Interface;
using GuestSide.Application.Interface.Advertisment;
using GuestSide.Application.Queries.GetEntity.Advertiment;
using GuestSide.Application.Queries.ListEntities.Advertisment;

namespace GuestSide.Application.Services
{
    public class AdvertismentService : IAdvertismentService
    {
        private readonly ICommandHandler<CreateAdvertisementCommand> CreateCommand;
        private readonly IValidator<CreateAdvertisementCommand> CreateValidation;
        private readonly ICommandHandler<UpdateAdvertisementCommand> UpdateCommand;
        private readonly IValidator<UpdateAdvertisementCommand> UpdateValidation;
        private readonly ICommandHandler<DeleteAdvertisementCommand> DeleteCommand;
        private readonly IValidator<DeleteAdvertisementCommand> DeleteValidation;
        private readonly IQueryHandler<GetAdvertisementByIdQuery,AdvertismentDto> getadvertisment;
        private readonly IValidator<GetAdvertisementByIdQuery> getAdvertismentByIdValidator;
        private readonly IQueryHandler<GetAllAdvertisementsQuery,IEnumerable<AdvertismentDto>> GetAllQuery;
        private readonly IMapper _mapper;

        public AdvertismentService(ICommandHandler<CreateAdvertisementCommand> CreateCommand, IValidator<CreateAdvertisementCommand> CreateValidation
            , ICommandHandler<UpdateAdvertisementCommand> UpdateCommand, IValidator<UpdateAdvertisementCommand> UpdateValidation,
            ICommandHandler<DeleteAdvertisementCommand> DeleteCommand, IValidator<DeleteAdvertisementCommand> DeleteValidation,
            IQueryHandler<GetAdvertisementByIdQuery, AdvertismentDto> getadvertisment, IValidator<GetAdvertisementByIdQuery> getAdvertismentByIdValidator,
            IQueryHandler<GetAllAdvertisementsQuery, IEnumerable<AdvertismentDto>> GetAllQuery,IMapper map)
        {
            this.CreateCommand = CreateCommand;
            this.CreateValidation = CreateValidation;
            this.UpdateCommand = UpdateCommand;
            this.DeleteCommand = DeleteCommand;
            this.DeleteValidation = DeleteValidation;
            this.UpdateValidation = UpdateValidation;
            this.getadvertisment = getadvertisment;
            this.getAdvertismentByIdValidator = getAdvertismentByIdValidator;
            this.GetAllQuery = GetAllQuery;
            this._mapper = map;
        }

        public async Task<bool> CreateAsync(AdvertismentDto entityDto)
        {
            var mappedCommand=_mapper.Map<CreateAdvertisementCommand>(entityDto);
            var validationResult=await CreateValidation.ValidateAsync(mappedCommand);
            if(!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors.Count.ToString());
            }
            await CreateCommand.Handle(mappedCommand);
            return true;
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var deleteComm = new DeleteAdvertisementCommand()
            {
                Id = id
            };
            var validationResult = await DeleteValidation.ValidateAsync(deleteComm);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors.Count.ToString());
            }
            await DeleteCommand.Handle(deleteComm);
            return true;
        }

        public async Task<IEnumerable<AdvertismentDto>> GetAllAsync()
        {
          var res= await GetAllQuery.Handle(new GetAllAdvertisementsQuery());
          return res;
        }

        public async Task<AdvertismentDto> GetByIdAsync(long id)
        {
            var getByIdCommand = new GetAdvertisementByIdQuery()
            {
                Id = id
            };
            var validate=await getAdvertismentByIdValidator.ValidateAsync(getByIdCommand);
            if (!validate.IsValid)
            {
                throw new ArgumentException(validate.Errors.Count.ToString());
            }
            var res = await getadvertisment.Handle(getByIdCommand);
            return res;
        }

        public async Task<bool> UpdateAsync(long id, AdvertismentDto entityDto)
        {
            var mappedCommand = _mapper.Map<UpdateAdvertisementCommand>(entityDto);
            var validationResult = await UpdateValidation.ValidateAsync(mappedCommand);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(validationResult.Errors.Count.ToString());
            }
            mappedCommand.Id=id;
            await UpdateCommand.Handle(mappedCommand);
            return true;
        }
    }
}
