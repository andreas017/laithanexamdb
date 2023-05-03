using FluentValidation;
using FluentValidation.AspNetCore;
using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingExamDb.Controllers
{
    [Route("api/v1/controller")]
    [ApiController]

    public class TheatreController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TheatreController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/new-theatre")]
        public async Task<ActionResult> Post([FromBody] CreateTheatreRequest model, [FromServices] IValidator<CreateTheatreRequest> validator)
        {
            var validationResult = await validator.ValidateAsync(model);

            if (validationResult.IsValid)
            {
                var response = await _mediator.Send(model);
                return Ok(response);
            }
            else
            {
                validationResult.AddToModelState(ModelState);
                return ValidationProblem(ModelState);
            }
        }

        [HttpGet("/theatres")]
        public async Task<ActionResult<List<GetTheatreResponse>>> Get()
        {
            var response = await _mediator.Send(new GetTheatreRequest());
            return Ok(response);
        }

    }
}
