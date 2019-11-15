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

        /// <summary>
        /// Restituisce il welcomeMessage assocaito al publicToken di input.
        /// </summary>
        /// <param name="publicToken">Rappresenta il token pubblico necessario al recupero dei dati del servizio</param>
        /// <returns></returns>
        public string Get(string publicToken)
        {
            return this.dbContext.ServiceCollection
                .Find(s => s.PublicToken == publicToken)
                .Project(s => s.WelcomeMessage)
                .Single();
        }
    }
}