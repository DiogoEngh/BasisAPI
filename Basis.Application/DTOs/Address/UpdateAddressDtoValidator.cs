using FluentValidation;

namespace Basis.Application.DTOs.Address
{
    public class UpdateAddressDtoValidator : AbstractValidator<UpdateAddressDto>
    {
        public UpdateAddressDtoValidator()
        {
            RuleFor(x => x.Street)
                .MaximumLength(250)
                .WithMessage("Rua não pode exceder 250 caracteres.");
            RuleFor(x => x.Neighborhood)
                .MaximumLength(250)
                .WithMessage("Bairro não pode exceder 250 caracteres.");
            RuleFor(x => x.City)
                .MaximumLength(250)
                .WithMessage("Cidade não pode exceder 250 caracteres.");
            RuleFor(x => x.State)
                .MaximumLength(250)
                .WithMessage("Estado não pode exceder 250 caracteres.");
            RuleFor(x => x.Zipcode)
                .Matches(@"^\d{8}$")
                .When(x => x.Zipcode != null)
                .WithMessage("CEP inválido");
            RuleFor(x => x.Country)
                .MaximumLength(250)
                .WithMessage("País não pode exceder 250 caracteres.");
            RuleFor(x => x.Complement)
                .MaximumLength(250)
                .WithMessage("Complemento não pode ser menor que 250 caracteres.");
        }
    }
}
