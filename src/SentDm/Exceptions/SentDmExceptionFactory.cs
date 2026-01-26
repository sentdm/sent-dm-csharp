using System.Net;

namespace SentDm.Exceptions;

public class SentDmExceptionFactory
{
    public static SentDmApiException CreateApiException(
        HttpStatusCode statusCode,
        string responseBody
    )
    {
        return (int)statusCode switch
        {
            400 => new SentDmBadRequestException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            401 => new SentDmUnauthorizedException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            403 => new SentDmForbiddenException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            404 => new SentDmNotFoundException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            422 => new SentDmUnprocessableEntityException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            429 => new SentDmRateLimitException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 400 and <= 499 => new SentDm4xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            >= 500 and <= 599 => new SentDm5xxException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
            _ => new SentDmUnexpectedStatusCodeException()
            {
                StatusCode = statusCode,
                ResponseBody = responseBody,
            },
        };
    }
}
