using System.Net;

namespace Shared.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message) : base(message, null, HttpStatusCode.NotFound)
    {
    }
}