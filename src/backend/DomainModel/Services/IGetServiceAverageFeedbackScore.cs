using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetServiceAverageFeedbackScore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IGetServiceAverageFeedbackScore
    {
        GetServiceAverageFeedbackScoreQueryResult Get(string privateToken);
    }
}
