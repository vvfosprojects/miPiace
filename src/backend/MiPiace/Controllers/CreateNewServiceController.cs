using CQRS.Commands;
using DomainModel.Classes;
using DomainModel.CQRS.Commands.CreateNewService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MiPiace.Helper;
using System;

namespace MiPiace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateNewServiceController : ControllerBase
    {
        private readonly ICommandHandler<CreateNewServiceCommand> handler;

        public CreateNewServiceController(ICommandHandler<CreateNewServiceCommand> handler)
        {
            this.handler = handler;
        }

        /// <summary>
        /// Il metodo Insert permette la creazione di un nuovo servizio con relativo welcomeMessage.
        /// Questo servizio verrà utilizzato una tantum, nel momento della registrazione dello stesso.
        /// </summary>
        /// <param name="welcomeMessage">
        /// Rappresenta il messaggio che verrà visualizzato nella pagina mostrata all'utente che
        /// vuole rilasciare il feedback.
        /// </param>
        /// <returns>200 Ok, se l'operazione è stata eseguita correttamente.</returns>
        [HttpPost]
        public ActionResult Insert([FromBody] string welcomeMessage)
        {
            var service = new CreateNewServiceCommand() 
            {
                WelcomeMessage = welcomeMessage
            };

            try
            {
                handler.Handle(service);
                return Created(service.Id, service);
            }
            
            catch
            {
                return BadRequest();
            }
        }
    }
}