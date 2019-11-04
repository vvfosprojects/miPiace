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
            var dictionaryScore = this.getSeriviceAverageFeedbackScore.Get(query.privateToken);

            return new GetServiceAverageFeedbackScoreQueryResult()
            {
                AverageScoreLastHour = dictionaryScore["averageScoreFeedbacksLastHour"],
                AverageScoreLastDay = dictionaryScore["averageScoreFeedbacksLastDay"],
                AverageScoreLastWeek = dictionaryScore["averageScoreFeedbacksLastWeek"],
                AverageScoreLastMonth = dictionaryScore["averageScoreFeedbacksLastMonth"],
                AverageScoreLastYear = dictionaryScore["averageScoreFeedbacksLastYear"],
                AverageScoreAllTime = dictionaryScore["averageScoreFeedbacksAllTime"]
            };
        }
    }
}
