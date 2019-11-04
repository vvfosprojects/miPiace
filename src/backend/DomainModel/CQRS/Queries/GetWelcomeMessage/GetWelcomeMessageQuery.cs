using CQRS.Queries;

namespace DomainModel.CQRS.Queries.GetWelcomeMessage
{
    public class GetWelcomeMessageQuery : IQuery<GetWelcomeMessageQueryResult>
    {
        public string PublicToken { get; set; }
    }
}