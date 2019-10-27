using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.MongoDB
{
    internal class SaveRating : ISaveRating
    {
        private readonly DbContext dbContext;

        public SaveRating(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Save(Feedback feedback)
        {
            dbContext.FeedbackCollection.InsertOne(feedback);
        }
    }
}