using FluentValidation;
using GameStore.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Bll.Validators
{
   public class PlatformValidators : AbstractValidator<PlatformCreateDto>
    {
        public PlatformValidators()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("type is required.");
        }
    }
}
