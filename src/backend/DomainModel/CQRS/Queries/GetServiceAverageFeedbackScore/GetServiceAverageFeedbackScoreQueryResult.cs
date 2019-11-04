namespace DomainModel.CQRS.Queries.GetServiceAverageFeedbackScore
{
    public class GetServiceAverageFeedbackScoreQueryResult 
    {
        public double AverageScoreLastHour { get; set; }
        public double AverageScoreLastDay { get; set; }
        public double AverageScoreLastWeek { get; set; }
        public double AverageScoreLastMonth { get; set; }
        public double AverageScoreLastYear { get; set; }
        public double AverageScoreAllTime { get; set; }


    }
}
