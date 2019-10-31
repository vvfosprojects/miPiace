using CQRS.Commands;
using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.InsertRating
{
    public class InsertRatingCommandHandler : ICommandHandler<InsertRatingCommand>
    {
        private readonly ISaveRating saveRating;

        public InsertRatingCommandHandler(ISaveRating saveRating)
        {
            this.saveRating = saveRating;
        }

        public void Handle(InsertRatingCommand command)
        {
            Rating ratingEnum;
            switch (command.Rating)
            {
                case "good":
                    ratingEnum = Rating.Good;
                    break;

                case "fair":
                    ratingEnum = Rating.Fair;
                    break;

                case "poor":
                    ratingEnum = Rating.Poor;
                    break;

                default:
                    throw new InvalidOperationException("Invalid rating");
            }

            var feedback = new Feedback()
            {
                Rating = ratingEnum,
                Host = command.Host,
                PublicToken = command.PublicToken
            };

            feedback.InstantUtc = DateTime.UtcNow;
            this.saveRating.Save(feedback);

            command.Id = feedback.Id;
        }
    }
}