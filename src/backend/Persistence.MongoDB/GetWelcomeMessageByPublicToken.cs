using DomainModel.Services;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.MongoDB
{
    internal class GetWelcomeMessageByPublicToken : IGetWelcomeMessageByPublicToken
    {
        private readonly DbContext dbContext;

        public GetWelcomeMessageByPublicToken(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string Get(string publicToken)
        {
            return this.dbContext.ServiceCollection
                .Find(s => s.PublicToken == publicToken)
                .Project(s => s.WelcomeMessage)
                .Single();
        }
    }
}