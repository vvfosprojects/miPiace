using CQRS.Commands;
using DomainModel.Services;

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
            this.createNewService.Insert(createNewService.PublicToken, createNewService.PublicToken, createNewService.WelcomeMessage);
        }
    }
}
