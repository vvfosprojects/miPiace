using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetServiceAverageFeedbackScore;
using Microsoft.AspNetCore.Mvc;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetServiceAverageFeedbackScoreController : ControllerBase
    {

        private readonly IQueryHandler<GetServiceAverageFeedbackScoreQuery, GetServiceAverageFeedbackScoreQueryResult> handler;

        public GetServiceAverageFeedbackScoreController(IQueryHandler<GetServiceAverageFeedbackScoreQuery, GetServiceAverageFeedbackScoreQueryResult> handler)
        {
            this.handler = handler;
        }
        
        [HttpGet]
        public ActionResult<GetServiceAverageFeedbackScoreQueryResult> Get ([FromQuery]GetServiceAverageFeedbackScoreQuery query)
        {
            return this.handler.Handle(query);
        }
    }
}