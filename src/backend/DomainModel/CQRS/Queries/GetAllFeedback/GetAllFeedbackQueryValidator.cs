using System.Collections.Generic;
using CQRS.Queries.Validators;
using CQRS.Validation;

namespace DomainModel.CQRS.Queries.GetAllFeedback
{
    public class GetAllFeedbackQueryValidator : IQueryValidator<GetAllFeedbackQuery, GetAllFeedbackQueryResult>
    {
        public IEnumerable<ValidationResult> Validate(GetAllFeedbackQuery query)
        {
            if (query.Page == 0 || query.Page == null)
            {
                query.Page = 1;
            }

            if (query.PageSize == 0 || query.PageSize == null)
            {
                query.PageSize = 10;
            }
            else if (query.PageSize > 20) query.PageSize = 20;

            if (string.IsNullOrWhiteSpace(query.PrivateToken))
            {
                yield return new ValidationResult("Errore, il privateToken non può essere vuoto!");
            }
            if (query.PrivateToken.Length > 32)
            {
                yield return new ValidationResult("Errore, la dimensione del privateToken è errata!");
            }
        }
    }
}
