using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.CreateNewService
{
    public class CreateNewServiceCommand
    {
        public Service Service { get; set; }
    }
}
