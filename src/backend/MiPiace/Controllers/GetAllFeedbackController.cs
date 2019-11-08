using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Queries;
using DomainModel.CQRS.Queries.GetAllFeedback;
using Microsoft.AspNetCore.Mvc;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class GetAllFeedbackController : ControllerBase
    {
        private readonly IQueryHandler<GetAllFeedbackQuery, GetAllFeedbackQueryResult> handler;

        public GetAllFeedbackController(IQueryHandler<GetAllFeedbackQuery, GetAllFeedbackQueryResult> handler)
        {
            this.handler = handler;
        }

        [HttpGet]
        public ActionResult<GetAllFeedbackQueryResult> Get([FromBody] GetAllFeedbackQuery query)
        {
            return this.handler.Handle(query);
        }
    }
}