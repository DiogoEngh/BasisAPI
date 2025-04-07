using System.Net;

namespace Basis.Domain.Common.Exceptions
{
    public class ConflictException : BaseHttpException
    {
        public ConflictException(string message) : base(message, HttpStatusCode.Conflict)
        {
        }
    }
}
