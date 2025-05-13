using FluentValidation;
using PS.NodeManagerFintech.Application.DTOs;

namespace PS.NodeManagerFintech.Application.Validators
{
    public class CreateTreeRequestValidator : AbstractValidator<CreateTreeRequest>
    {
        public CreateTreeRequestValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .WithMessage("Name must be at most 100 characters.");
        }
    }
}
