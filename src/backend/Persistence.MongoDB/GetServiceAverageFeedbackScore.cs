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

            List<Feedback> feedbacksLastHour = feedbackCollection.Find(f => f.PublicToken == servicePublicToken && f.InstantUtc.Date == utcNow.Date && f.InstantUtc.Hour >= utcNow.AddHours(-1).Hour && f.InstantUtc.Hour <= utcNow.Hour).ToList();
            List<Feedback> feedbacksLastDay = feedbackCollection.Find(f => f.PublicToken == servicePublicToken && f.InstantUtc.Date >= utcNow.Date.AddDays(-1) && f.InstantUtc.Date <= utcNow.Date).ToList();
            List<Feedback> feedbacksLastWeek = feedbackCollection.Find(f => f.PublicToken == servicePublicToken && f.InstantUtc.Date >= utcNow.Date.AddDays(-7) && f.InstantUtc.Date <= utcNow.Date).ToList();
            List<Feedback> feedbacksLastMonth = feedbackCollection.Find(f => f.PublicToken == servicePublicToken && f.InstantUtc.Date >= utcNow.Date.AddMonths(-1) && f.InstantUtc.Date <= utcNow.Date).ToList();
            List<Feedback> feedbacksLastYear = feedbackCollection.Find(f => f.PublicToken == servicePublicToken && f.InstantUtc.Date >= utcNow.Date.AddYears(-1) && f.InstantUtc.Date <= utcNow.Date).ToList();
            List<Feedback> feedbacksAllTime = feedbackCollection.Find(f => f.PublicToken == servicePublicToken).ToList();

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
                averageScoreFeedbacksLastHour += GetRating(feedback.Rating.ToString());
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
            switch (rate)
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
