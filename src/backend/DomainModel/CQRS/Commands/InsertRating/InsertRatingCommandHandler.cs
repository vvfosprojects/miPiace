using CQRS.Commands;
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
            command.Feedback.InstantUtc = DateTime.UtcNow;
            this.saveRating.Save(command.Feedback);
        }
    }
}