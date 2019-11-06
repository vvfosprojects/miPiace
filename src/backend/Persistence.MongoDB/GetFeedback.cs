using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetFeedback;
using DomainModel.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.MongoDB
{
    public class GetFeedback : IGetFeedback
    {
        private readonly DbContext dbContext;

        public GetFeedback (DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Feedback Get(GetFeedbackQuery query)
        {
            var collectionServices = dbContext.ServiceCollection;
            var filterBuilderPrivateToken = Builders<Service>.Filter;
            var filterPrivateToken = filterBuilderPrivateToken.Eq(x => x.PrivateToken, query.privateToken);
            var servicePublicToken = collectionServices.Find(filterPrivateToken).Single();

            var collectionFeedback = dbContext.FeedbackCollection;
            var filterBuilderId = Builders<Feedback>.Filter;
            var filterId = filterBuilderId.Eq(x => x.Id, query.Id) &
                           filterBuilderId.Eq(x => x.PublicToken, servicePublicToken.PublicToken);

            return collectionFeedback.Find(filterId).Single();
        }
    }
}
