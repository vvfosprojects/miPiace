using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface ICreateNewService
    {
        void Insert(string publicToken, string privateToken, string welcomeMessage);
    }
}
