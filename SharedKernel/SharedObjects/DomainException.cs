using System.Net;

namespace SharedKernel.SharedObjects
{
    public class DomainException : ApplicationException
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.BadRequest;

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public DomainException(string message, int statusCode, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
        }
    }
}
