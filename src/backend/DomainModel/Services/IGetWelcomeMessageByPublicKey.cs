using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IGetWelcomeMessageByPublicToken
    {
        string Get(string publicToken);
    }
}