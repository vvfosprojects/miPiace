using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetAllFeedback
{
    public class GetAllFeedbackQueryResult
    {
        public List<Feedback> AllFeedback { get; set; }

        public CriteriDiRicerca CriteriDiRicerca { get; set; }
    }
}
