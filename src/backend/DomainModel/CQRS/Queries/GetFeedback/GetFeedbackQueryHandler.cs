using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetFeedback
{
    public class GetFeedbackQueryHandler : IQueryHandler<GetFeedbackQuery, GetFeedbackQueryResult>
    {
        private readonly IGetFeedback getFeedback;

        public GetFeedbackQueryHandler(IGetFeedback getFeedback)
        {
            this.getFeedback = getFeedback ?? throw new ArgumentNullException(nameof(getFeedback));

        }

        public GetFeedbackQueryResult Handle(GetFeedbackQuery query)
        {
            Feedback feedback = this.getFeedback.Get(query.Id, query.PrivateToken);

            return new GetFeedbackQueryResult() {Feedback = feedback};
        }
    }
}
