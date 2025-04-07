using System.Net;

namespace Basis.Domain.Common.Exceptions
{
    public class BadRequestException : BaseHttpException
    {
        public BadRequestException(string message)
            : base(message, HttpStatusCode.BadRequest) { }

        public BadRequestException(IEnumerable<string> errors)
            : base(errors, HttpStatusCode.BadRequest) { }
    }
}