using CQRS.Queries;

namespace DomainModel.CQRS.Queries.GetServiceAverageFeedbackScore
{
    public class GetServiceAverageFeedbackScoreQuery : IQuery<GetServiceAverageFeedbackScoreQueryResult>
    {
        public string privateToken { get; set; }
    }
}
