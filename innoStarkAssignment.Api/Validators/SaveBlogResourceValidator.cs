using System;
using FluentValidation;
using innoStarkAssignment.Api.Resources;

namespace innoStarkAssignment.Api.Validators
{
    public class SaveBlogResourceValidator : AbstractValidator<SaveBlogResource>
    {
        public SaveBlogResourceValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(m => m.CategoryId)
                .NotEmpty()
                .WithMessage("'Category Id' must not be 0.");
        }
    }
}
