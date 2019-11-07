using DomainModel.Classes;
using DomainModel.CQRS.Queries.GetAllFeedbackByFilter;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IGetAllFeedbackByRating
    {
        List<Feedback> Get(string privateToken, Rating rating);
    }
}
