using FilmManagement.Application.Exceptions.Types;
using FluentValidation;
using MediatR;
using ValidationException = FilmManagement.Application.Exceptions.Types.ValidationException;

namespace FilmManagement.Application.Pipelines.Validation
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            ValidationContext<object> context = new(request);
            var validationResults = _validators.Select(validator => validator.Validate(context)).ToList();
            var failures = validationResults.SelectMany(result => result.Errors).Where(failure => failure != null).ToList();

            if (failures.Count != 0)
            {
                var errors = failures.GroupBy(f => f.PropertyName, f => f.ErrorMessage,
                    (propertyName, errorMessages) => new ValidationExceptionModel
                    {
                        Property = propertyName,
                        Errors = errorMessages.ToList()
                    }).ToList();

                throw new ValidationException(errors);
            }

            return await next();
        }
    }
}
