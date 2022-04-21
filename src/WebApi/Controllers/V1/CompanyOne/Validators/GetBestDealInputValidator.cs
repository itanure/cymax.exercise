using Application.Boundaries.CompanyOne;
using FluentValidation;

namespace WebApi.Controllers.V1.CompanyOne.Validators
{
    public class GetBestDealInputValidator: AbstractValidator<GetBestDealInput>
    {
        public GetBestDealInputValidator()
        {
            RuleFor(prop => prop.Offer)
                .NotNull()
                .WithMessage("Offer cannot be null.");

            RuleFor(prop => prop.Offer.ContactAddress)
                .NotNull()
                .NotEqual(new Address())
                .WithMessage("ContactAddress cannot be null or empty.");

            RuleFor(prop => prop.Offer.WarehouseAddress)
                .NotNull()
                .NotEqual(new Address())
                .WithMessage("WarehouseAddress cannot be null or empty.");

            RuleFor(prop => prop.Offer.Dimensions)
                .NotNull()
                .NotEmpty()
                .WithMessage("Dimensions cannot be null or empty.");
        }
    }
}
