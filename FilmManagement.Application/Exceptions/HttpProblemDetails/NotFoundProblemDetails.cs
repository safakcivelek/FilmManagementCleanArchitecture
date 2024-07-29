using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.Application.Exceptions.HttpProblemDetails
{
    internal class NotFoundProblemDetails : ProblemDetails
    {
        public NotFoundProblemDetails(string detail)
        {
            Title = "Bulunamadı";
            Detail = detail;
            Status = StatusCodes.Status404NotFound;
            Type = "https://example.com/probs/notfound";
        }
    }
}
