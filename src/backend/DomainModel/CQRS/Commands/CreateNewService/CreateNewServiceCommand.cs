using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.CreateNewService
{
    public class CreateNewServiceCommand
    { 
        public string Id { get; set; }

        public string PrivateToken { get; set; }

        public string PublicToken { get; set; }

        public string WelcomeMessage { get; set; }
    }
}
