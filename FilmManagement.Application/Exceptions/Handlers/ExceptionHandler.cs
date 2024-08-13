using FilmManagement.Application.Exceptions.Types;

namespace FilmManagement.Application.Exceptions.Handlers
{
    public abstract class ExceptionHandler
    {
        public Task HandleExceptionAsync(Exception exception) =>
            exception switch
            {
                BusinessException businessException => HandleException(businessException),
                NotFoundException notFoundException => HandleException(notFoundException),
                AuthorizationException authorizationException=> HandleException(authorizationException),
                ValidationException validationException => HandleException(validationException),
                _ => HandleException(exception)
            };

        protected abstract Task HandleException(BusinessException businessException);
        protected abstract Task HandleException(NotFoundException notFoundException);
        protected abstract Task HandleException(AuthorizationException authorizationException);
        protected abstract Task HandleException(ValidationException validationException);
        protected abstract Task HandleException(Exception exception);
    }
}
