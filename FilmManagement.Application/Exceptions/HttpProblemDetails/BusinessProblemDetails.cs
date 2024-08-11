using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmManagement.Application.Exceptions.HttpProblemDetails
{
    internal class BusinessProblemDetails : ProblemDetails
    {
        public BusinessProblemDetails(string detail)
        {
            Title = "Kural ihlali";
            Detail = detail;
            Status = StatusCodes.Status400BadRequest; // 422 olabilrmi ?
            Type = "https://example.com/probs/business";
        }
    }
}
