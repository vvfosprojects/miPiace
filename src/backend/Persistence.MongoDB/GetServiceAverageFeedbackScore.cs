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

        public GetServiceAverageFeedbackScore(DbContext dbContext )
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
            var filterBuilderAllTimeGood = Builders<Feedback>.Filter;
            var filterBuilderAllTimeFair = Builders<Feedback>.Filter;
            var filterBuilderAllTimePoor = Builders<Feedback>.Filter;


            //recupero tutti i feedback registrati negli ultimi 60 min
            var filterHour = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, DateTime.UtcNow.AddHours(-1)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, DateTime.UtcNow);
            
            //recupero tutti i feedback registrati nel giornata antecedente la data odierna 
            var filterDay = filterBuilderDay.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderDay.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-1)) &
                             filterBuilderDay.Lt(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati nel corso dell'ultima settimana (compresi quelli registrati nella giornata odierna)
            var filterWeek = filterBuilderWeek.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderWeek.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-6)) &
                             filterBuilderWeek.Lte(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati nel corso dell'ultimo mese(compresi quelli registrati nella giornata odierna)
            var filterMonth = filterBuilderMonth.Eq(x => x.PublicToken, servicePublicToken) &
                              filterBuilderMonth.Gte(x => x.InstantUtc, DateTime.UtcNow.AddDays(-30)) &
                              filterBuilderMonth.Lte(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati nel corso dell'ultimo anno (compresi quelli registrati nella giornata odierna)
            var filterYear = filterBuilderYear.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderYear.Gte(x => x.InstantUtc, DateTime.UtcNow.AddYears(-1)) &
                             filterBuilderYear.Lte(x => x.InstantUtc, DateTime.UtcNow);

            //recupero tutti i feedback registrati
            var filterAllTime = filterBuilderAllTime.Eq(x => x.PublicToken, servicePublicToken);

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

            var filterAllTimeGood = filterBuilderAllTimeGood.Eq(x => x.PublicToken, servicePublicToken) & 
                                    filterBuilderAllTimeGood.Eq(x => x.Rating, Rating.Good);

            var filterAllTimeFair = filterBuilderAllTimeFair.Eq(x => x.PublicToken, servicePublicToken) &
                                    filterBuilderAllTimeFair.Eq(x => x.Rating, Rating.Fair);

            var filterAllTimePoor = filterBuilderAllTimePoor.Eq(x => x.PublicToken, servicePublicToken) &
                                    filterBuilderAllTimePoor.Eq(x => x.Rating, Rating.Poor);

            double feedbacksAllTimeGood = feedbackCollection.Find(filterAllTimeGood).ToList().Count(); //feedbacksAllTimeList.Where(x => x.Rating == Rating.Good).Count();
            double feedbacksAllTimeFair = feedbackCollection.Find(filterAllTimeFair).ToList().Count();
            double feedbacksAllTimePoor = feedbackCollection.Find(filterAllTimePoor).ToList().Count();

            var facetStatList = new List<FacetStatistiche>();
            //var url = configuration.GetSection("BasePath").Value;

            facetStatList.Add(new FacetStatistiche()
            {
                Voto = "good",
                Percentuale = feedbacksAllTimeGood / (double)feedbacksAllTimeList.Count,
               // FeedbackLink = url + "?privateToken=" + privateToken + "&rating=" + 3
            }); 
            facetStatList.Add(new FacetStatistiche() 
            { 
                Voto = "fair", 
                Percentuale = feedbacksAllTimeFair / (double)feedbacksAllTimeList.Count,
               // FeedbackLink = url + "?privateToken=" + privateToken + "&rating=" + 2
            });
            facetStatList.Add(new FacetStatistiche() 
            { 
                Voto = "poor", 
                Percentuale = feedbacksAllTimePoor / (double)feedbacksAllTimeList.Count,
               // FeedbackLink = url + "?privateToken=" + privateToken + "&rating=" + 1
            });


            return new GetServiceAverageFeedbackScoreQueryResult()
            {
                feedbackAverageScores = feedbackAverageScoreList,
                facetStatistiche = facetStatList
            };

        }

        /// <summary>
        /// Il metodo presa in input una stringa contenente un Rating assegna un punteggio (intero) 
        /// </summary>
        /// <param name="rate">Accetta in input un stringa con possibili valori (Good, Fair, Poor)</param>
        /// <returns></returns>
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
