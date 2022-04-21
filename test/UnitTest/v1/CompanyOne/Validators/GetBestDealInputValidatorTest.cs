using System;
using Application.Boundaries.CompanyOne;
using FluentValidation.TestHelper;
using WebApi.Controllers.V1.CompanyOne.Validators;
using Xunit;

namespace UnitTest.v1.CompanyOne.Validators
{
    public class GetBestDealInputValidatorTest
    {
        private readonly GetBestDealInputValidator _validator;
        public GetBestDealInputValidatorTest()
        {
            _validator = new GetBestDealInputValidator();
        }

        [Fact]
        [Trait("CompanyOne", "ShouldValidContactAddress")]
        public void ShouldValidContactAddress()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    ContactAddress = new Address()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.ContactAddress);
        }

        [Fact]
        [Trait("CompanyOne", "ShouldInvalidContactAddress")]
        public void ShouldInvalidContactAddress()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    ContactAddress = null
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.ContactAddress);
        }
        [Fact]
        [Trait("CompanyOne", "ShouldValidWarehouseAddress")]
        public void ShouldValidWarehouseAddress()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    WarehouseAddress = new Address()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.WarehouseAddress);
        }

        [Fact]
        [Trait("CompanyOne", "ShouldInvalidWarehouseAddress")]
        public void ShouldInvalidWarehouseAddress()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    WarehouseAddress = null
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.WarehouseAddress);
        }
        [Fact]
        [Trait("CompanyOne", "ShouldValidDimensions")]
        public void ShouldValidDimensions()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Dimensions = new PackageDimensions[]
                    {
                        new PackageDimensions(),
                        new PackageDimensions()
                    }
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Offer.Dimensions);
        }

        [Fact]
        [Trait("CompanyOne", "ShouldInvalidDimensions")]
        public void ShouldInvalidDimensions()
        {
            var model = new GetBestDealInput
            {
                Offer = new Offer
                {
                    Dimensions = Array.Empty<PackageDimensions>()
                }
            };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Offer.Dimensions);
        }
    }
}
