using Application.Boundaries.CompanyThree;
using FluentValidation;

namespace WebApi.Controllers.V1.CompanyThree.Validators
{
    public class GetBestDealInputValidator: AbstractValidator<GetBestDealInput>
    {
        public GetBestDealInputValidator()
        {
            RuleFor(prop => prop.Offer)
                .NotNull()
                .WithMessage("Offer cannot be null.");

            RuleFor(prop => prop.Offer.Destination)
                .NotNull()
                .NotEqual(new Address())
                .WithMessage("Destination cannot be null or empty.");

            RuleFor(prop => prop.Offer.Source)
                .NotNull()
                .NotEqual(new Address())
                .WithMessage("Source cannot be null or empty.");

            RuleFor(prop => prop.Offer.Packages)
                .NotNull()
                .NotEmpty()
                .WithMessage("Packages cannot be null or empty.");
        }
    }
}
