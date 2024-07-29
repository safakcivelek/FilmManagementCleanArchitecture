using FilmManagement.Application.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;

namespace FilmManagement.Application.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly HttpExceptionHandler _httpExceptionHandler;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
            _httpExceptionHandler = new HttpExceptionHandler();
        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                //Sonraki middleware'a geçiş yapılır
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext.Response, exception);
            }
        }

        private Task HandleExceptionAsync(HttpResponse response, Exception exception)
        {
            response.ContentType = "application/json";
            _httpExceptionHandler.Response = response;
            return _httpExceptionHandler.HandleExceptionAsync(exception);
        }

        // LogException : Log yönetimi daha sonra sağlanacak. 
    }
}
