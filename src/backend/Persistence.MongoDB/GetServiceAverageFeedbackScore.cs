using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetServiceAverageFeedbackScore;
using DomainModel.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.MongoDB
{
    public class GetServiceAverageFeedbackScore : IGetServiceAverageFeedbackScore
    {
        private readonly DbContext dbContext;

        public GetServiceAverageFeedbackScore(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public GetServiceAverageFeedbackScoreQueryResult Get(string privateToken)
        {
            List<FeedbackAverageScore> feedbackAverageScoreList = new List<FeedbackAverageScore>();

            var serviceCollection = dbContext.ServiceCollection;

            string servicePublicToken = serviceCollection.Find(s => s.PrivateToken == privateToken).Project(t => t.PublicToken).Single();

            var feedbackCollection = dbContext.FeedbackCollection;

            var filterBuilderHour = Builders<Feedback>.Filter;
            var filterBuilderDay = Builders<Feedback>.Filter;
            var filterBuilderWeek = Builders<Feedback>.Filter;
            var filterBuilderMonth = Builders<Feedback>.Filter;
            var filterBuilderYear = Builders<Feedback>.Filter;
            var filterBuilderAllTime = Builders<Feedback>.Filter;

            var filterHour = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddHours(-1)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);

            var filterDay = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-1)) &
                             filterBuilderHour.Lt(x => x.InstantUtc, DateTime.UtcNow);

            var filterWeek = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-6)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);

            var filterMonth = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                              filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-30)) &
                              filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);

            var filterYear = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddYears(-1)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);

            var filterAllTime = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken);

            List<Feedback> feedbacksLastHour = feedbackCollection.Find(filterHour).ToList();
            List<Feedback> feedbacksLastDay = feedbackCollection.Find(filterDay).ToList();
            List<Feedback> feedbacksLastWeek = feedbackCollection.Find(filterWeek).ToList();
            List<Feedback> feedbacksLastMonth = feedbackCollection.Find(filterMonth).ToList();
            List<Feedback> feedbacksLastYear = feedbackCollection.Find(filterYear).ToList();
            List<Feedback> feedbacksAllTimeList = feedbackCollection.Find(filterAllTime).ToList();

            var averageScoreFeedbacksLastHour = 0.0;
            var averageScoreFeedbacksLastDay = 0.0;
            var averageScoreFeedbacksLastWeek = 0.0;
            var averageScoreFeedbacksLastMonth = 0.0;
            var averageScoreFeedbacksLastYear = 0.0;
            var averageScoreFeedbacksAllTime = 0.0;

            foreach (var feedback in feedbacksLastHour)
            {
                averageScoreFeedbacksLastHour += GetRating(feedback.Rating.ToString());
            }

            foreach (var feedback in feedbacksLastDay)
            {
                averageScoreFeedbacksLastDay += GetRating(feedback.Rating.ToString());

            }

            foreach (var feedback in feedbacksLastWeek)
            {
                averageScoreFeedbacksLastWeek += GetRating(feedback.Rating.ToString());
            }

            foreach (var feedback in feedbacksLastMonth)
            {
                averageScoreFeedbacksLastMonth += GetRating(feedback.Rating.ToString());
            }

            foreach (var feedback in feedbacksLastYear)
            {
                averageScoreFeedbacksLastYear += GetRating(feedback.Rating.ToString());
            }

            foreach (var feedback in feedbacksAllTimeList)
            {
                averageScoreFeedbacksAllTime += GetRating(feedback.Rating.ToString());
            }

            feedbackAverageScoreList.Add(new FeedbackAverageScore() 
            {   
                Intervallo = "averageScoreFeedbacksLastHour", 
                Average = averageScoreFeedbacksLastHour / feedbacksLastHour.Count
            });

            feedbackAverageScoreList.Add(new FeedbackAverageScore()
            { 
                Intervallo = "averageScoreFeedbacksLastDay",
                Average = averageScoreFeedbacksLastDay / feedbacksLastDay.Count
            });
            feedbackAverageScoreList.Add(new FeedbackAverageScore()
            {
                Intervallo = "averageScoreFeedbacksLastWeek",
                Average = averageScoreFeedbacksLastWeek / feedbacksLastWeek.Count
            });
            feedbackAverageScoreList.Add(new FeedbackAverageScore()
            { 
                Intervallo = "averageScoreFeedbacksLastMonth",
                Average = averageScoreFeedbacksLastMonth / feedbacksLastMonth.Count
            });
            feedbackAverageScoreList.Add(new FeedbackAverageScore() 
            {
                Intervallo = "averageScoreFeedbacksLastYear", 
                Average = averageScoreFeedbacksLastYear / feedbacksLastYear.Count
            });
            feedbackAverageScoreList.Add(new FeedbackAverageScore() 
            {
                Intervallo = "averageScoreFeedbacksAllTime",
                Average = averageScoreFeedbacksAllTime / feedbacksAllTimeList.Count
            });

            //Costruisco la percentuale dei voti raccolti sulla base di tutti i feedback registrati

            double feedbacksAllTimeGood = feedbacksAllTimeList.Where(x => x.Rating == Rating.Good).Count();
            double feedbacksAllTimeFair = feedbacksAllTimeList.Where(x => x.Rating == Rating.Fair).Count();
            double feedbacksAllTimePoor = feedbacksAllTimeList.Where(x => x.Rating == Rating.Poor).Count();

            var facetStatList = new List<FacetStatistiche>();

            facetStatList.Add(new FacetStatistiche() { Voto = "good", Percentuale = feedbacksAllTimeGood / (double)feedbacksAllTimeList.Count });
            facetStatList.Add(new FacetStatistiche() { Voto = "fair", Percentuale = feedbacksAllTimeFair / (double)feedbacksAllTimeList.Count });
            facetStatList.Add(new FacetStatistiche() { Voto = "poor", Percentuale = feedbacksAllTimePoor / (double)feedbacksAllTimeList.Count });


            var getServiceAverageFeedbackScoreQueryResult = new GetServiceAverageFeedbackScoreQueryResult()
            {
                feedbackAverageScores = feedbackAverageScoreList,
                facetStatistiche = facetStatList
            };

            return getServiceAverageFeedbackScoreQueryResult;
        }


        protected int GetRating (string rate)
        {
            var score = 0;
            switch (rate.ToLower())
            {
                case "good":
                    score = 3;
                    return score;

                case "fair":
                    score = 2;
                    return score;

                case "poor":
                    score = 1;
                    return score;

                default:
                    score = 0;
                    return score;
            }
        }
    }
}
