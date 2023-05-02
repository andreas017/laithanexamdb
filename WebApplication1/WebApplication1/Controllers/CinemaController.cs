using FluentValidation;
using FluentValidation.AspNetCore;
using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrainingExamDb.Controllers
{
    [Route("api/v1/address")]
    [ApiController]
    public class CinemaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CinemaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("/new-cinema")]
        public async Task<ActionResult> Post([FromBody] NewCinemaRequest model, [FromServices] IValidator<NewCinemaRequest> validator)
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

        [HttpGet("/cinemas")]
        public async Task<ActionResult<List<GetCinemaResponse>>> Get()
        {
            var response = await _mediator.Send(new GetCinemaRequest());
            return Ok(response);
        }

        /*[HttpPut("/update-user")]
        public async Task<ActionResult> Put([FromBody] UpdateUserRequest model, [FromServices] IValidator<UpdateUserRequest> validator)
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
        }*/
    }
}
