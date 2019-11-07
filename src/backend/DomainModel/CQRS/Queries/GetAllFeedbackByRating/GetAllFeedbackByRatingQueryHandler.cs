using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetAllFeedbackByFilter
{
    public class GetAllFeedbackByRatingQueryHandler : IQueryHandler<GetAllFeedbackByRatingQuery, GetAllFeedbackByRatingQueryResult>
    {
        private readonly IGetAllFeedbackByRating getAllFeedbackByFilter;

        public GetAllFeedbackByRatingQueryHandler(IGetAllFeedbackByRating getAllFeedbackByFilter)
        {
            this.getAllFeedbackByFilter = getAllFeedbackByFilter ?? throw new ArgumentNullException(nameof(getAllFeedbackByFilter));
        }

        public GetAllFeedbackByRatingQueryResult Handle(GetAllFeedbackByRatingQuery query)
        {
            List<Feedback> feedbackList = this.getAllFeedbackByFilter.Get(query.PrivateToken, query.Rating);

            return new GetAllFeedbackByRatingQueryResult() { AllFeedback = feedbackList };
        }
    }
}
