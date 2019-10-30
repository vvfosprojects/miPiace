using CQRS.Commands;
using DomainModel.Classes;
using DomainModel.CQRS.Commands.CreateNewService;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MiPiace.Controllers
{
    public class CreateNewServiceController : Controller
    {

        private readonly ICommandHandler<CreateNewServiceCommand> handler;

        public CreateNewServiceController(ICommandHandler<CreateNewServiceCommand> handler)
        {
            this.handler = handler;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Insert([FromBody] string welcomeMessage)
        {
            var service = new CreateNewServiceCommand()
            {
                Service = new Service()
                {
                    Id = new Guid(),
                    PrivateToken = "",
                    PublicToken = "",
                    WelcomeMessage = welcomeMessage
                }
            };
            handler.Handle(service);

            return Ok();
        }
    }
}

    