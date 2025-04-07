using Basis.Domain.Common.Exceptions;
using System.Text.RegularExpressions;

namespace Basis.Domain.Aggregates.CustomerAggregate
{
    public class Zipcode
    {
        public string Value { get; private set; }
        public Zipcode(string? value)
        {
            Value = value?.Trim();
            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new BadRequestException("O CEP não pode ser vazio.");

            if (!Regex.IsMatch(Value, @"^\d{8}$"))
                throw new BadRequestException("O CEP deve conter exatamente 8 dígitos numéricos, sem traços ou espaços.");
        }
    }
}
