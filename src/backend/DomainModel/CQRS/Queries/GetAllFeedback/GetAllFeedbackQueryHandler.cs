using CQRS.Queries;
using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetAllFeedback
{
    public class GetAllFeedbackQueryHandler : IQueryHandler<GetAllFeedbackQuery, GetAllFeedbackQueryResult>
    {
        private readonly IGetAllFeedback getAllFeedback;

        public GetAllFeedbackQueryHandler(IGetAllFeedback getAllFeedback)
        {
            this.getAllFeedback = getAllFeedback ?? throw new ArgumentNullException(nameof(getAllFeedback));
        }

        public GetAllFeedbackQueryResult Handle(GetAllFeedbackQuery query)
        {
            List<Feedback> feedbackList = this.getAllFeedback.Get(query.PrivateToken, query.Rating, (int)query.Page, (int)query.PageSize);

            return new GetAllFeedbackQueryResult()
            {
                AllFeedback = feedbackList,
                CriteriDiRicerca = new CriteriDiRicerca()
                {
                    Page = (int)query.Page,
                    FirstIndex = (int)((query.Page - 1) * query.PageSize),
                    LastIndex = (int)(((query.Page - 1) * query.PageSize) + query.PageSize - 1),
                    PageSize = (int)query.PageSize,
                    Rating = query.Rating.ToString(),
                    PrivateToken = query.PrivateToken,
                    TotalItems = this.getAllFeedback.Get(query.PrivateToken, query.Rating, 0,0).Count
                }
            };
        }
    }
}
