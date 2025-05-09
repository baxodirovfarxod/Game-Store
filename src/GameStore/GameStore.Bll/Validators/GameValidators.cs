using FluentValidation;
using GameStore.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.Bll.Validators
{
    // Assuming the correct DTO class is GameDto within the Bll.Dtos namespace
    public class GameValidators : AbstractValidator<GameDto>
    {
        public GameValidators()
        {
            RuleFor(game => game.Name)
                .NotEmpty()
                .WithMessage("Game name is required.")
                .Length(3, 50)
                .WithMessage("Game name must be between 1 and 100 characters.");
        }
    }

    }
}
