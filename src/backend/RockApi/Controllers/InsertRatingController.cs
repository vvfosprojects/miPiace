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
        public ActionResult<string> Post([FromBody] string rating)
        {
            Rating ratingEnum;
            switch (rating)
            {
                case "good":
                    ratingEnum = Rating.Good;
                    break;

                case "fair":
                    ratingEnum = Rating.Fair;
                    break;

                case "poor":
                    ratingEnum = Rating.Poor;
                    break;

                default:
                    throw new InvalidOperationException("Invalid rating");
            }

            var ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var command = new InsertRatingCommand()
            {
                Feedback = new Feedback()
                {
                    Rating = ratingEnum,
                    Host = ip,
                }
            };
            handler.Handle(command);

            return Ok(new { id = command.Feedback.Id });
        }
    }
}