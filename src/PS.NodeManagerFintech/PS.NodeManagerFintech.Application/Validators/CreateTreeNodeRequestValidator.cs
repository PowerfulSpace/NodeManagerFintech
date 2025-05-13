using FluentValidation;
using PS.NodeManagerFintech.Application.DTOs;

namespace PS.NodeManagerFintech.Application.Validators
{
    public class CreateTreeNodeRequestValidator : AbstractValidator<CreateTreeNodeRequest>
    {
        public CreateTreeNodeRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Node name is required.")
                .MaximumLength(100).WithMessage("Name must be at most 100 characters.");

            RuleFor(x => x.TreeId)
                .NotEmpty().WithMessage("TreeId is required.");
        }
    }
}
