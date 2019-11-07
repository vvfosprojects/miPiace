using DomainModel.Classes;
using DomainModel.Services;
using MongoDB.Driver;


namespace Persistence.MongoDB
{
    public class GetFeedback : IGetFeedback
    {
        private readonly DbContext dbContext;

        public GetFeedback (DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Feedback Get(string id, string privateToken)
        {
            var collectionServices = dbContext.ServiceCollection;
            var filterBuilderPrivateToken = Builders<Service>.Filter;
            var filterPrivateToken = filterBuilderPrivateToken.Eq(x => x.PrivateToken, privateToken);
            var servicePublicToken = collectionServices.Find(filterPrivateToken).Single();

            var collectionFeedback = dbContext.FeedbackCollection;
            var filterBuilderId = Builders<Feedback>.Filter;
            var filterId = filterBuilderId.Eq(x => x.Id, id) &
                           filterBuilderId.Eq(x => x.PublicToken, servicePublicToken.PublicToken);

            return collectionFeedback.Find(filterId).Single();
        }
    }
}
