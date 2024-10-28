using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class PsychologistValidator : AbstractValidator<Psychologist>
    {
        public PsychologistValidator()
        {
            RuleFor(x => x.Title).NotEmpty();
            RuleFor(x => x.ImageUrl).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
