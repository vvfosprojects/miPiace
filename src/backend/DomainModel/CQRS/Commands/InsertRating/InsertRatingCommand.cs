using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.InsertRating
{
    public class InsertRatingCommand
    {
        public Feedback Feedback { get; set; }
    }
}