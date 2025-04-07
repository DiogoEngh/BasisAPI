using Basis.Domain.Common.Exceptions;
using System.Net.Mail;

namespace Basis.Domain.Aggregates.CustomerAggregate
{
    public class Email
    {
        public string Value { get; private set; }

        public Email(string value)
        {
            Value = value.Trim().ToLowerInvariant();
            Validate();
        }

        private void Validate()
        {
            try
            {
                var mailAddress = new MailAddress(Value);
            }
            catch
            {
                throw new BadRequestException("E-mail inválido");
            }
        }
    }
}
