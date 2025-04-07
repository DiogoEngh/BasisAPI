using FluentValidation;

namespace Basis.Application.DTOs.Customer
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name é obrigatório.")
                .MaximumLength(250)
                .WithMessage("Nome não pode exceder 250 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email é obrigatório.")
                .EmailAddress()
                .WithMessage("Email inválido.")
                .MaximumLength(250)
                .WithMessage("Email não pode exceder 250 caracteres.");
        }
    }
}
