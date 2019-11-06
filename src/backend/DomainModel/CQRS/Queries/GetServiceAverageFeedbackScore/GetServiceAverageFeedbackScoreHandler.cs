using CQRS.Queries;
using DomainModel.Services;
using System;

namespace DomainModel.CQRS.Queries.GetServiceAverageFeedbackScore
{
    public class GetServiceAverageFeedbackScoreHandler : IQueryHandler<GetServiceAverageFeedbackScoreQuery, GetServiceAverageFeedbackScoreQueryResult>
    {
        private readonly IGetServiceAverageFeedbackScore getSeriviceAverageFeedbackScore;

        public GetServiceAverageFeedbackScoreHandler(IGetServiceAverageFeedbackScore getSeriviceAverageFeedbackScore)
        {
            this.getSeriviceAverageFeedbackScore = getSeriviceAverageFeedbackScore ?? throw new ArgumentNullException(nameof(getSeriviceAverageFeedbackScore)); ;
        }

        public GetServiceAverageFeedbackScoreQueryResult Handle(GetServiceAverageFeedbackScoreQuery query)
        {
            return this.getSeriviceAverageFeedbackScore.Get(query.privateToken);
        }
    }
}
