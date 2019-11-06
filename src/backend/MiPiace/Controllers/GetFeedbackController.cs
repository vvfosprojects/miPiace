using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetFeedback;
using Microsoft.AspNetCore.Mvc;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetFeedbackController : ControllerBase
    {

        private readonly IQueryHandler<GetFeedbackQuery, GetFeedbackQueryResult> handler;


        public GetFeedbackController(IQueryHandler<GetFeedbackQuery, GetFeedbackQueryResult> handler)
        {
            this.handler = handler;        
        }

        [HttpGet]
        public ActionResult<GetFeedbackQueryResult> Get([FromQuery] GetFeedbackQuery query)
        {
            return this.handler.Handle(query);
        }
    }
}