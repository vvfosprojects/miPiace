using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetFeedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IGetFeedback
    {
        Feedback Get(string id, string privateToken); 
    }
}
