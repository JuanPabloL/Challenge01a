using Application.Common.Constants;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;


namespace Application.Common.Exceptions
{
    public class ValidationException : BadHttpRequestException
    {
        public ValidationException(IEnumerable<ValidationFailure> errors)
            : base(Messages.ValidationsErrorMessage)
        {
            Errors = errors;
        }

        public IEnumerable<ValidationFailure> Errors { get; private set; } = [];
    }

}
