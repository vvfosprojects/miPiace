using DomainModel.Classes;
using DomainModel.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;


namespace Persistence.MongoDB
{
    public class GetServiceAverageFeedbackScore : IGetServiceAverageFeedbackScore
    {
        private readonly DbContext dbContext;

        public GetServiceAverageFeedbackScore(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Dictionary<string, double> Get(string privateToken)
        {
            Dictionary<string, double> scoreDictionary = new Dictionary<string, double>();

            var serviceCollection = dbContext.ServiceCollection;

            string servicePublicToken = serviceCollection.Find(s => s.PrivateToken == privateToken).Project(t => t.PublicToken).Single();

            var feedbackCollection = dbContext.FeedbackCollection;

            DateTime utcNow = DateTime.UtcNow;

            var filterBuilderHour = Builders<Feedback>.Filter;
            var filterBuilderDay = Builders<Feedback>.Filter;
            var filterBuilderWeek = Builders<Feedback>.Filter;
            var filterBuilderMonth = Builders<Feedback>.Filter;
            var filterBuilderYear = Builders<Feedback>.Filter;
            var filterBuilderAllTime = Builders<Feedback>.Filter;

            var filterHour = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, utcNow.AddHours(-1)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, utcNow);

            var filterDay = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, utcNow.AddDays(-1)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, utcNow);

            var filterWeek = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, utcNow.AddDays(-7)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, utcNow);

            var filterMonth = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                              filterBuilderHour.Gte(x => x.InstantUtc, utcNow.AddDays(-31)) &
                              filterBuilderHour.Lte(x => x.InstantUtc, utcNow);

            var filterYear = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken) &
                             filterBuilderHour.Gte(x => x.InstantUtc, utcNow.AddDays(-365)) &
                             filterBuilderHour.Lte(x => x.InstantUtc, utcNow);

            var filterAllTime = filterBuilderHour.Eq(x => x.PublicToken, servicePublicToken);

            List<Feedback> feedbacksLastHour = feedbackCollection.Find(filterHour).ToList();
            List<Feedback> feedbacksLastDay = feedbackCollection.Find(filterDay).ToList();
            List<Feedback> feedbacksLastWeek = feedbackCollection.Find(filterWeek).ToList();
            List<Feedback> feedbacksLastMonth = feedbackCollection.Find(filterMonth).ToList();
            List<Feedback> feedbacksLastYear = feedbackCollection.Find(filterYear).ToList();
            List<Feedback> feedbacksAllTime = feedbackCollection.Find(filterAllTime).ToList();


            var averageScoreFeedbacksLastHour = 0.0;
            var averageScoreFeedbackLastDay = 0.0;
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
                averageScoreFeedbackLastDay += GetRating(feedback.Rating.ToString());
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

            foreach (var feedback in feedbacksAllTime)
            {
                averageScoreFeedbacksAllTime += GetRating(feedback.Rating.ToString());
            }

            
            scoreDictionary.Add("averageScoreFeedbacksLastHour", averageScoreFeedbacksLastHour / feedbacksLastHour.Count);
            scoreDictionary.Add("averageScoreFeedbacksLastDay", averageScoreFeedbackLastDay / feedbacksLastDay.Count);
            scoreDictionary.Add("averageScoreFeedbacksLastWeek", averageScoreFeedbacksLastWeek / feedbacksLastWeek.Count);
            scoreDictionary.Add("averageScoreFeedbacksLastMonth", averageScoreFeedbacksLastMonth / feedbacksLastMonth.Count);
            scoreDictionary.Add("averageScoreFeedbacksLastYear", averageScoreFeedbacksLastYear / feedbacksLastYear.Count);
            scoreDictionary.Add("averageScoreFeedbacksAllTime", averageScoreFeedbacksAllTime / feedbacksLastYear.Count);

            return scoreDictionary;
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
