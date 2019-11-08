using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetServiceAverageFeedbackScore;
using DomainModel.Services;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace Persistence.MongoDB
{
    public class GetServiceAverageFeedbackScore : IGetServiceAverageFeedbackScore
    {
        private readonly DbContext dbContext;
        private readonly IConfiguration configuration;

        public GetServiceAverageFeedbackScore(DbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
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

            //recupero tutti i feedback registrati negli ultimi 60 min
            var filterHour = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddHours(-1)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);
            
            //recupero tutti i feedback registrati nel giornata antecedente la data odierna 
            var filterDay = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-1)) &
                             filterBuilderHour.Lt(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati nel corso dell'ultima settimana (compresi quelli registrati nella giornata odierna)
            var filterWeek = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-6)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati nel corso dell'ultimo mese(compresi quelli registrati nella giornata odierna)
            var filterMonth = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                              filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-30)) &
                              filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati nel corso dell'ultimo anno (compresi quelli registrati nella giornata odierna)
            var filterYear = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddYears(-1)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati
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

            //aggiungo alla lista di output la media dei valori registrati divisi per intervallo temporale
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
            var url = configuration.GetSection("BasePath").Value;

            facetStatList.Add(new FacetStatistiche() 
            { 
                Voto = "good", 
                Percentuale = feedbacksAllTimeGood / (double)feedbacksAllTimeList.Count,
                FeedbackLink = url
            });
            facetStatList.Add(new FacetStatistiche() 
            { 
                Voto = "fair", 
                Percentuale = feedbacksAllTimeFair / (double)feedbacksAllTimeList.Count,
                FeedbackLink = url
            });
            facetStatList.Add(new FacetStatistiche() 
            { 
                Voto = "poor", 
                Percentuale = feedbacksAllTimePoor / (double)feedbacksAllTimeList.Count,
                FeedbackLink = url
            });


            return new GetServiceAverageFeedbackScoreQueryResult()
            {
                feedbackAverageScores = feedbackAverageScoreList,
                facetStatistiche = facetStatList
            };

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
