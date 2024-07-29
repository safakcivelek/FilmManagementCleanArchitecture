using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FilmManagement.Application.Exceptions.Extensions
{
    internal static class ProblemDetailsExtensions
    {
        public static string AsJson<TProblemDetail>(this TProblemDetail details)
            where TProblemDetail : ProblemDetails => JsonSerializer.Serialize(details);
    }
}
