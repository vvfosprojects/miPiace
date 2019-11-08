using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IGetAllFeedback
    {
        List<Feedback> Get(string privateToken, Rating? rating, int page, int pageSize);
    }
}
