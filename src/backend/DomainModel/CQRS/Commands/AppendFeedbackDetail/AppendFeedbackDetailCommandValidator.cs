using CQRS.Authorization;
using CQRS.Commands.Validators;
using CQRS.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AppendFeedbackDetail
{
    public class AppendFeedbackDetailCommandValidator : ICommandValidator<AppendFeedbackDetailCommand>
    {
        public IEnumerable<ValidationResult> Validate(AppendFeedbackDetailCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.FeedbackId))
                yield return new ValidationResult("Feedback id cannot be null");

            if (string.IsNullOrWhiteSpace(command.Text))
                yield return new ValidationResult("Feedback text cannot be null");
        }
    }
}