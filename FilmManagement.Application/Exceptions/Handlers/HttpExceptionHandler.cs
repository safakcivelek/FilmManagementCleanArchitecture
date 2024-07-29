using FilmManagement.Application.Exceptions.Extensions;
using FilmManagement.Application.Exceptions.HttpProblemDetails;
using FilmManagement.Application.Exceptions.Types;
using Microsoft.AspNetCore.Http;

namespace FilmManagement.Application.Exceptions.Handlers
{
    public class HttpExceptionHandler : ExceptionHandler
    {
        public HttpResponse Response
        {
            get => _response ?? throw new ArgumentNullException(nameof(_response));
            set => _response = value;
        }

        private HttpResponse? _response;

        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = new BusinessProblemDetails(businessException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(NotFoundException notFoundException)
        {
            Response.StatusCode = StatusCodes.Status404NotFound;
            string details = new NotFoundProblemDetails(notFoundException.Message).AsJson();
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = new InternalServerErrorProblemDetails(exception.Message).AsJson(); 
            return Response.WriteAsync(details);
        }
    }
}
