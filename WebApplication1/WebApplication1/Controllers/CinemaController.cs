﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Lib.Interface;
using Lib.RequestModel;
using Lib.ResponseModel;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training.Sql.Entity.Entity;

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

        [HttpPut("/update-cinema")]
        public async Task<ActionResult> Put([FromBody] UpdateCinemaRequest model, [FromServices] IValidator<UpdateCinemaRequest> validator)
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

        [HttpGet("offset-pagination")]
        public async Task<ActionResult<GetCinemaOffsetPaginationResponse>> Get(int limit, int offset)
        {
            var response = await _mediator.Send(new GetCinemaRequest
            {
                Limit = limit,
                Offset = offset
            });
            return Ok(response);
        }
    }
}
