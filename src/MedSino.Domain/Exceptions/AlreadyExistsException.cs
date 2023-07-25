using System.Net;

namespace MedSino.Domain.Exceptions;

public class AlreadyExistsException : ClientException
{
    public override HttpStatusCode StatusCode { get; } = HttpStatusCode.Conflict;

    public override string TitleMessage { get; protected set; } = String.Empty;
}
