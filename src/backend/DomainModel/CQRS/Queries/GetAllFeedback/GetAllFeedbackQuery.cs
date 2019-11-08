using CQRS.Queries;
using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetAllFeedback
{
    public class GetAllFeedbackQuery : IQuery<GetAllFeedbackQueryResult>
    {
        public string PrivateToken { get; set; }

        public Rating? Rating { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }
    }
}
