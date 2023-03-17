using FluentValidation;
using Skelp.Api.BindingModels;

namespace Skelp.Api.Validation;

public class CreateUserValidator: AbstractValidator<CreateUser>
{
    public CreateUserValidator() {
        RuleFor(x => x.FirstName).NotNull();
        RuleFor(x => x.LastName).NotNull();
    }
}