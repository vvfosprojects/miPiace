using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface ICreateNewService
    {
        void Insert(Service service);
    }
}
