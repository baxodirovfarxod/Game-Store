using FluentValidation;
using GameStore.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Bll.Validators
{
   public class GenreValidators : AbstractValidator<GenreCreateDto>
    {
        public GenreValidators()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MinimumLength(2).WithMessage("Name must be at least 2 characters long.");
        }
    }
}
