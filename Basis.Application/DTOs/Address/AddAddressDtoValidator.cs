using FluentValidation;

namespace Basis.Application.DTOs.Address
{
    public class AddAddressDtoValidator : AbstractValidator<AddAddressDto>
    {
        public AddAddressDtoValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty()
                .WithMessage("Rua é obrigatório.")
                .MaximumLength(250)
                .WithMessage("Rua não pode exceder 250 caracteres.");

            RuleFor(x => x.Neighborhood)
                .NotEmpty()
                .WithMessage("Bairro é obrigatório.")
                .MaximumLength(250)
                .WithMessage("Bairro não pode exceder 250 caracteres.");

            RuleFor(x => x.City)
                .NotEmpty()
                .WithMessage("Cidade é obrigatório.")
                .MaximumLength(250)
                .WithMessage("Cidade não pode exceder 250 caracteres.");

            RuleFor(x => x.State)
                .NotEmpty()
                .WithMessage("Estado é obrigatório.")
                .MaximumLength(250)
                .WithMessage("Estado não pode exceder 250 caracteres.");

            RuleFor(x => x.Zipcode)
                .NotEmpty()
                .WithMessage("CEP é obrigatório.")
                .Matches(@"^\d{8}$")
                .WithMessage("CEP inválido.");

            RuleFor(x => x.Country)
                .NotEmpty()
                .WithMessage("País é obrigatório.")
                .MaximumLength(250)
                .WithMessage("País não pode exceder 250 caracteres.");

            RuleFor(x => x.Complement)
                .MaximumLength(250)
                .WithMessage("Complemento não pode ser menor que 250 caracteres.");
        }
    }
}