using System.Net;

namespace Basis.Domain.Common.Exceptions
{
    public class NotFoundException : BaseHttpException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound)
        {
        }
    }
}
