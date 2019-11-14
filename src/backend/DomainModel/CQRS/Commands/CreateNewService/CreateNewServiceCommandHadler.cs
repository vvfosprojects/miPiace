using CQRS.Commands;
using DomainModel.Classes;
using DomainModel.Services;
using MiPiace.Helper;

namespace DomainModel.CQRS.Commands.CreateNewService
{
    public class CreateNewServiceCommandHandler : ICommandHandler<CreateNewServiceCommand>
    {
        private readonly ICreateNewService createNewService;

        public CreateNewServiceCommandHandler(ICreateNewService createNewService)
        {
            this.createNewService = createNewService;
        }

        public void Handle(CreateNewServiceCommand createNewService)
        { 
            var service = new Service()
            {
                PrivateToken = GenerateToken.Generate(24),
                PublicToken = GenerateToken.Generate(24),
                WelcomeMessage = createNewService.WelcomeMessage
            };
            
            this.createNewService.Insert(service);

            createNewService.Id = service.Id;
            createNewService.PrivateToken = service.PrivateToken;
            createNewService.PublicToken = service.PublicToken;
        }
    }
}
