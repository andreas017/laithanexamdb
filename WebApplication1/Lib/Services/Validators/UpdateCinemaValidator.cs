using FluentValidation;
using Lib.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Validators
{
    public class UpdateCinemaValidator : AbstractValidator<UpdateCinemaRequest>
    {
        public UpdateCinemaValidator()
        {
            RuleFor(Q => Q.Address).NotEmpty().MinimumLength(10).MaximumLength(100);
        }
    }
}
