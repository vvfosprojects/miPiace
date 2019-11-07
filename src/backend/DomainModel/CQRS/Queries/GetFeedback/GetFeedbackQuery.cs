using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetFeedback
{
    public class GetFeedbackQuery : IQuery<GetFeedbackQueryResult>
    {
        public string Id { get; set; }

        public string PrivateToken { get; set; }
    }
}
