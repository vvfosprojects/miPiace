using System;
using System.Collections.Generic;
using System.Text;
using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetAllFeedbackByFilter;
using DomainModel.Services;
using MongoDB.Driver;

namespace Persistence.MongoDB
{
    public class GetAllFeedbackByFilter : IGetAllFeedbackByRating
    {
        private readonly DbContext dbContext;

        public GetAllFeedbackByFilter(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Feedback> Get(string privateToken, Rating rating)
        {
            var collectionService = dbContext.ServiceCollection;

            var builderFilterService = Builders<Service>.Filter;
            var filterPrivateToken = builderFilterService.Eq(x => x.PrivateToken, privateToken);

            var publicToken = collectionService.Find(filterPrivateToken).Single();

            var collectionFeedback = dbContext.FeedbackCollection;

            var builderFilterFeedbackByRating = Builders<Feedback>.Filter;
            var filterRating = builderFilterFeedbackByRating.Eq(x => (int) x.Rating, (int)rating) &
                               builderFilterFeedbackByRating.Eq(x => x.PublicToken, publicToken.PublicToken);

            return collectionFeedback.Find(filterRating).ToList();
        }
    }
}
