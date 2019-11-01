using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetWelcomeMessage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetWelcomeMessageController : ControllerBase
    {
        private readonly IQueryHandler<GetWelcomeMessageQuery, GetWelcomeMessageQueryResult> handler;

        public GetWelcomeMessageController(IQueryHandler<GetWelcomeMessageQuery, GetWelcomeMessageQueryResult> handler)
        {
            this.handler = handler;
        }

        // GET: api/GetWelcomeMessage/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(string id)
        {
            var query = new GetWelcomeMessageQuery()
            {
                PublicToken = id
            };

            var welcomeMessage = this.handler.Handle(query);

            return "\"" + welcomeMessage.WelcomeMessage + "\"";
        }
    }
}