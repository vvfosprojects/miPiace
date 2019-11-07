using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetAllFeedbackByFilter;
using Microsoft.AspNetCore.Mvc;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetAllFeedbackByRatingController : ControllerBase
    {
        private readonly IQueryHandler<GetAllFeedbackByRatingQuery, GetAllFeedbackByRatingQueryResult> handler;

        public GetAllFeedbackByRatingController(IQueryHandler<GetAllFeedbackByRatingQuery, GetAllFeedbackByRatingQueryResult> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public ActionResult<GetAllFeedbackByRatingQueryResult> Get([FromQuery] GetAllFeedbackByRatingQuery query)
        {
            return this.handler.Handle(query);
        }
    }
}