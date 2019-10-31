using CQRS.Commands.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.InsertRating
{
    public class InsertRatingCommandValidator : ICommandValidator<InsertRatingCommand>
    {
        public IEnumerable<ValidationResult> Validate(InsertRatingCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Host))
                yield return new ValidationResult("Host cannot be null");

            if (!string.IsNullOrWhiteSpace(command.Id))
                yield return new ValidationResult("Feedback id must be null");
        }
    }
}