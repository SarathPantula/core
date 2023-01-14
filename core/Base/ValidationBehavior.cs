using core.Models.DefaultResponses;
using FluentValidation;
using MediatR;

namespace core.Base;

/// <summary>
/// 
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : IDefaultResponse, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    /// <summary>
    /// ctor
    /// </summary>
    /// <param name="validators"></param>
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    /// <summary>
    /// Handler
    /// </summary>
    /// <param name="request"></param>
    /// <param name="next"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var failures = _validators
            .Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(f => f != null)
            .Select(error => new ErrorInfo(Convert.ToInt64(error.ErrorCode), error.ErrorMessage))
            .ToList();

        if (failures.Any())
        {
            return new TResponse
            {
                Errors = failures
            };
        }

        return await next();
    }
}