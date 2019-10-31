using System;
using System.Threading.Tasks;
using CQRS.Commands;
using DomainModel.Classes;
using DomainModel.CQRS.Commands.InsertRating;
using Microsoft.AspNetCore.Mvc;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsertRatingController : ControllerBase
    {
        private readonly ICommandHandler<InsertRatingCommand> handler;

        public InsertRatingController(ICommandHandler<InsertRatingCommand> handler)
        {
            this.handler = handler;
        }

        // POST: api/InsertRating
        [HttpPost]
        public ActionResult<string> Post(InsertRatingCommand command)
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            command.Host = ip;
            handler.Handle(command);

            return Ok(new { id = command.Id });
        }
    }
}