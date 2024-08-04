using FluentValidation;

namespace GuestSide.Application.Queries.GetEntity.Advertiment
{
    public class GetAdvertisementByIdQueryValidator : AbstractValidator<GetAdvertisementByIdQuery>
    {
        public GetAdvertisementByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
