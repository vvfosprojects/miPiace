using CQRS.Queries;
using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetAllFeedbackByFilter
{
    public class GetAllFeedbackByRatingQuery : IQuery<GetAllFeedbackByRatingQueryResult>
    {
        public string PrivateToken { get; set; }

        public Rating Rating { get; set; }

        public int? Intervallo { get; set; }
    }
}
