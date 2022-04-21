using System;
using Application.Boundaries.CompanyTwo;
using FluentValidation.TestHelper;
using WebApi.Controllers.V1.CompanyTwo.Validators;
using Xunit;

namespace UnitTest.v1.CompanyTwo.Validators
{
    public class GetBestDealInputValidatorTest
    {
        private readonly GetBestDealInputValidator _validator;
        public GetBestDealInputValidatorTest()
        {
            _validator = new GetBestDealInputValidator();
        }

        [Fact]
        [Trait("CompanyTwo", "ShouldValidConsignee")]
        public void ShouldValidConsignee()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Consignee = new Address()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.Consignee);
        }

        [Fact]
        [Trait("CompanyTwo", "ShouldInvalidConsignee")]
        public void ShouldInvalidConsignee()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Consignee = null
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.Consignee);
        }
        [Fact]
        [Trait("CompanyTwo", "ShouldValidConsignor")]
        public void ShouldValidConsignor()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Consignor = new Address()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.Consignor);
        }

        [Fact]
        [Trait("CompanyTwo", "ShouldInvalidConsignor")]
        public void ShouldInvalidConsignor()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Consignor = null
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.Consignor);
        }
        [Fact]
        [Trait("CompanyTwo", "ShouldValidCartons")]
        public void ShouldValidCartons()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                     Cartons = new CartonsDimension[]
                    {
                        new CartonsDimension(),
                        new CartonsDimension()
                    }
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.Cartons);
        }

        [Fact]
        [Trait("CompanyTwo", "ShouldInvalidCartons")]
        public void ShouldInvalidCartons()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Cartons = Array.Empty<CartonsDimension>()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.Cartons);
        }
    }
}
