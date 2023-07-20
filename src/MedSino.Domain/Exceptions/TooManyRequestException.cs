using System.Net;

namespace MedSino.Domain.Exceptions;

public class TooManyRequestException : Exception
{
    public HttpStatusCode StatusCode { get; } = HttpStatusCode.TooManyRequests;

    public string TitleMessage { get; protected set; } = String.Empty;
}
