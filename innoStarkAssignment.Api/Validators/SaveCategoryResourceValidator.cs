using FluentValidation;
using innoStarkAssignment.Api.Resources;

namespace innoStarkAssignment.Api.Validators
{
    public class SaveCategoryResourceValidator : AbstractValidator<SaveCategoryResource>
    {
        public SaveCategoryResourceValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
