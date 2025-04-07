using System.Net;

namespace Basis.Domain.Common.Exceptions
{
    public abstract class BaseHttpException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public IEnumerable<string> Errors { get; }

        protected BaseHttpException(string message, HttpStatusCode statusCode)
            : base(message)
        {
            StatusCode = statusCode;
            Errors = new List<string> { message };
        }

        protected BaseHttpException(IEnumerable<string> errors, HttpStatusCode statusCode)
            : base(errors?.FirstOrDefault() ?? "Erro inesperado.")
        {
            StatusCode = statusCode;
            Errors = errors ?? new List<string>();
        }
    }
}
