﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.V1.CompanyTwo.Builders;
using WebApi.Controllers.V1.CompanyTwo.Request;
using WebApi.Controllers.V1.CompanyTwo.Validators;

namespace WebApi.Controllers.V1.CompanyTwo
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/companytwo")]
    [ApiController]
    public class OffersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<OffersController> _logger;
        public OffersController(IMediator mediator, ILogger<OffersController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost("offers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync(
            [FromBody] CompanyTwoOfferRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var input = GetOfferUseCaseInputBuilder.Create()
                    .WithConsignee(request.Consignee)
                    .WithConsignor(request.Consignor)
                    .WithCartons(request.Cartons);

                var inputValidationResult = await new GetBestDealInputValidator().ValidateAsync(input, cancellationToken);

                if (!inputValidationResult.IsValid)
                {
                    return BadRequest(inputValidationResult.Errors.Select(prop => prop.ErrorMessage));
                }

                var result = await _mediator.Send(input, cancellationToken);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{@controller}] - The request failed due to an internal error", nameof(OffersController));
                return StatusCode((int)HttpStatusCode.InternalServerError, "Error while get best deal of CompanyOne!");
            }
        }
    }
}
