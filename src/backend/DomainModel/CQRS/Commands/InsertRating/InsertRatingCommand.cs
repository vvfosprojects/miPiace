using DomainModel.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.InsertRating
{
    public class InsertRatingCommand
    {
        public string Rating { get; set; }
        public string PublicToken { get; set; }
        public string Host { get; set; }
        public string Id { get; set; } // output field
    }
}