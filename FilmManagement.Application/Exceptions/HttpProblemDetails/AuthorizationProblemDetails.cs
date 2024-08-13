using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.Application.Exceptions.HttpProblemDetails
{
    internal class AuthorizationProblemDetails : ProblemDetails
    {
        public AuthorizationProblemDetails(string detail)
        {
            Title = "Yetkilendirme Hatası";
            Detail = detail;
            Status = StatusCodes.Status401Unauthorized;
            Type = "https://example.com/probs/authorization";
        }
    }
}
