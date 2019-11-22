using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DomainModel.Classes;
using DomainModel.Services;
using MongoDB.Driver;

namespace Persistence.MongoDB
{
    public class GetAllFeedback : IGetAllFeedback
    {
        private readonly DbContext dbContext;

        public GetAllFeedback(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Feedback> Get(string privateToken, Rating? rating, int page, int pageSize)
        {
            var collectionService = dbContext.ServiceCollection;
            var builderFilterService = Builders<Service>.Filter;
            var filterPrivateToken = builderFilterService.Eq(x => x.PrivateToken, privateToken);
            var publicToken = collectionService.Find(filterPrivateToken).Single();
            var collectionFeedback = dbContext.FeedbackCollection;
            var builderFilterFeedbackByRating = Builders<Feedback>.Filter;
            if (rating != null)
            {
                var filterRating = builderFilterFeedbackByRating.Eq(x => (int)x.Rating, (int)rating) &
                               builderFilterFeedbackByRating.Eq(x => x.PublicToken, publicToken.PublicToken);
                var allFeedback = collectionFeedback.Find(filterRating).ToList().OrderByDescending(x => x.Rating);
                return allFeedback.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                var filterRating = builderFilterFeedbackByRating.Eq(x => x.PublicToken, publicToken.PublicToken);
                var allFeedback = collectionFeedback.Find(filterRating).ToList().OrderByDescending(x => x.Rating);
                if (page == 0 && pageSize == 0)
                {
                    return allFeedback.ToList();
                }
                return allFeedback.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }
        }
    }
}
