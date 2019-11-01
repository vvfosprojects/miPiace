using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Commands;
using DomainModel.CQRS.Commands.AppendFeedbackDetail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppendFeedbackDetailController : ControllerBase
    {
        private readonly ICommandHandler<AppendFeedbackDetailCommand> handler;

        public AppendFeedbackDetailController(ICommandHandler<AppendFeedbackDetailCommand> handler)
        {
            this.handler = handler;
        }

        // POST: api/AppendFeedbackDetail
        [HttpPost]
        public ActionResult Post([FromBody] AppendFeedbackDetailCommand dto)
        {
            handler.Handle(dto);

            return Ok();
        }
    }
}