using System;
using Application.Boundaries.CompanyThree;
using FluentValidation.TestHelper;
using WebApi.Controllers.V1.CompanyThree.Validators;
using Xunit;

namespace UnitTest.v1.CompanyThree.Validators
{
    public class GetBestDealInputValidatorTest
    {
        private readonly GetBestDealInputValidator _validator;
        public GetBestDealInputValidatorTest()
        {
            _validator = new GetBestDealInputValidator();
        }

        [Fact]
        [Trait("CompanyThree", "ShouldValidDestination")]
        public void ShouldValidDestination()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Destination = new Address()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.Destination);
        }

        [Fact]
        [Trait("CompanyThree", "ShouldInvalidDestination")]
        public void ShouldInvalidDestination()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Destination = null
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.Destination);
        }
        [Fact]
        [Trait("CompanyThree", "ShouldValidSource")]
        public void ShouldValidSource()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Source = new Address()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.Source);
        }

        [Fact]
        [Trait("CompanyThree", "ShouldInvalidSource")]
        public void ShouldInvalidSource()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Source = null
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.Source);
        }
        [Fact]
        [Trait("CompanyThree", "ShouldValidPackages")]
        public void ShouldValidPackages()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Packages = new Package[]
                    {
                        new Package(),
                        new Package()
                    }
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.Packages);
        }

        [Fact]
        [Trait("CompanyThree", "ShouldInvalidPackages")]
        public void ShouldInvalidPackages()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Packages = Array.Empty<Package>()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.Packages);
        }
    }
}
