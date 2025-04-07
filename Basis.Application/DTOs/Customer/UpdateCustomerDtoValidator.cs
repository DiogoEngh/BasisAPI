using FluentValidation;

namespace Basis.Application.DTOs.Customer
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name é obrigatório.")
                .MaximumLength(250)
                .WithMessage("Nome não pode exceder 250 caracteres.");
        }
    }
}
