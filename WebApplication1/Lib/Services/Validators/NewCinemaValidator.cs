using FluentValidation;
using Lib.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Validators
{
    public class NewCinemaValidator : AbstractValidator<NewCinemaRequest>
    {
        public NewCinemaValidator()
        {
            RuleFor(Q => Q.Name).NotEmpty().MinimumLength(5).MaximumLength(20);
            RuleFor(Q => Q.Address).NotEmpty().MinimumLength(10).MaximumLength(100);
        }
    }
}
