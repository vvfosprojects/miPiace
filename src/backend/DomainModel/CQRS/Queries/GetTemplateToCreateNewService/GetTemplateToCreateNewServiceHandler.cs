using CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Queries.GetTemplateToCreateNewService
{
    public class GetTemplateToCreateNewServiceHandler : IQueryHandler<GetTemplateToCreateNewServiceQuery, GetTemplateToCreateNewServiceQueryResult>
    {
        public GetTemplateToCreateNewServiceQueryResult Handle(GetTemplateToCreateNewServiceQuery query)
        {
            return new GetTemplateToCreateNewServiceQueryResult() { };
        }
    }
}