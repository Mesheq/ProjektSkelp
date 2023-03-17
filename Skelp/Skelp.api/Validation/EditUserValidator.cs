using FluentValidation;
using Skelp.Api.BindingModels;



namespace Skelp.Api.Validation
{
    public class EditUserValidator : AbstractValidator<EditUser>
    {
        public EditUserValidator() {
            RuleFor(x => x.FirstName).NotNull();
           
      
           
        }
    }
}