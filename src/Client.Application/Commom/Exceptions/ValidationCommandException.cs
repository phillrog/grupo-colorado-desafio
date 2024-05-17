using FluentValidation.Results;

namespace Client.Application.Commom.Exceptions
{
    public class ValidationCommandException : Exception
    {
        public ValidationCommandException()
            : base("Ocorreram uma ou mais falhas de validação.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public ValidationCommandException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
