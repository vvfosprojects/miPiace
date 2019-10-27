using DomainModel.Classes;
using DomainModel.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.MongoDB
{
    internal class AppendFeedbackDetail : IAppendFeedbackDetail
    {
        private readonly DbContext dbContext;

        public AppendFeedbackDetail(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Append(string feedbackId, string text, string user, string contacts)
        {
            var updateCommand = Builders<Feedback>.Update
                .Set(f => f.FeedbackText, text)
                .Set(f => f.User, user)
                .Set(f => f.UserContacts, contacts);

            var result = dbContext.FeedbackCollection.UpdateOne(f => f.Id == feedbackId, updateCommand);

            long modifiedCount = result.ModifiedCount;
            if (modifiedCount != 1)
                throw new InvalidOperationException($"The number of updated records is { modifiedCount }. Should have been 1.");
        }
    }
}