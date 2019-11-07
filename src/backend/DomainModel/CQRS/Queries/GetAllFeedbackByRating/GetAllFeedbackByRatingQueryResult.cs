using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetAllFeedbackByFilter
{
    public class GetAllFeedbackByRatingQueryResult
    {
        public List<Feedback> AllFeedback { get; set; }
    }
}
