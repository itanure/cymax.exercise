using Application.Boundaries.CompanyTwo;
using FluentValidation;

namespace WebApi.Controllers.V1.CompanyTwo.Validators
{
    public class GetBestDealInputValidator: AbstractValidator<GetBestDealInput>
    {
        public GetBestDealInputValidator()
        {
            RuleFor(prop => prop.Offer)
                .NotNull()
                .WithMessage("Offer cannot be null.");

            RuleFor(prop => prop.Offer.Consignee)
                .NotNull()
                .NotEqual(new Address())
                .WithMessage("Consignee cannot be null or empty.");

            RuleFor(prop => prop.Offer.Consignor)
                .NotNull()
                .NotEqual(new Address())
                .WithMessage("Consignor cannot be null or empty.");

            RuleFor(prop => prop.Offer.Cartons)
                .NotNull()
                .NotEmpty()
                .WithMessage("Cartons cannot be null or empty.");
        }
    }
}
