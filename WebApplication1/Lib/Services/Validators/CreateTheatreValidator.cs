using FluentValidation;
using Lib.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Services.Validators
{
    public class CreateTheatreValidator : AbstractValidator<CreateTheatreRequest>
    {
        public CreateTheatreValidator()
        {
            RuleFor(Q => Q.Name).NotEmpty().MinimumLength(5).MaximumLength(20);
        }
    }
}
