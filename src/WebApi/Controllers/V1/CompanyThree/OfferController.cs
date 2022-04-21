using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Controllers.V1.CompanyThree.Builders;
using WebApi.Controllers.V1.CompanyThree.Request;
using WebApi.Controllers.V1.CompanyThree.Validators;

namespace WebApi.Controllers.V1.CompanyThree
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/companythree")]
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
        [Consumes("application/xml")]
        public async Task<IActionResult> GetAsync(
            [FromBody] CompanyThreeRequest request,
            CancellationToken cancellationToken)
        {
            try
            {
                var input = GetOfferUseCaseInputBuilder.Create()
                    .WithDestination(request.Destination)
                    .WithSource(request.Source)
                    .WithPackages(request.Packages);

                var inputValidationResult = await new GetBestDealInputValidator().ValidateAsync(input, cancellationToken);

                if (!inputValidationResult.IsValid)
                {
                    var badRequestResult = BadRequest(inputValidationResult.Errors.Select(prop => prop.ErrorMessage));
                    badRequestResult.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
                    return badRequestResult;
                }

                var result = await _mediator.Send(input, cancellationToken);

                OkObjectResult okResult = Ok(result);
                okResult.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
                return okResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[{@controller}] - The request failed due to an internal error", nameof(OffersController));
                var internalServerResult = StatusCode((int)HttpStatusCode.InternalServerError, "Error while get best deal of CompanyThree!");
                internalServerResult.Formatters.Add(new Microsoft.AspNetCore.Mvc.Formatters.XmlSerializerOutputFormatter());
                return internalServerResult;
            }
        }
    }
}
