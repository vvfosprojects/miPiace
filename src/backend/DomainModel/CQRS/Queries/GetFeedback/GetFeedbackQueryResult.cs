using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetFeedback
{
    public class GetFeedbackQueryResult
    {
        public Feedback Feedback { get; set; }
    }
}
