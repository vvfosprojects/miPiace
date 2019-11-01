using CQRS.Queries;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetWelcomeMessage
{
    public class GetWelcomeMessageQueryHandler : IQueryHandler<GetWelcomeMessageQuery, GetWelcomeMessageQueryResult>
    {
        private readonly IGetWelcomeMessageByPublicToken getWelcomeMessageByPublicKey;

        public GetWelcomeMessageQueryHandler(IGetWelcomeMessageByPublicToken getWelcomeMessageByPublicKey)
        {
            this.getWelcomeMessageByPublicKey = getWelcomeMessageByPublicKey;
        }

        public GetWelcomeMessageQueryResult Handle(GetWelcomeMessageQuery query)
        {
            var welcomeMessage = this.getWelcomeMessageByPublicKey.Get(query.PublicToken);

            return new GetWelcomeMessageQueryResult() { WelcomeMessage = welcomeMessage };
        }
    }
}