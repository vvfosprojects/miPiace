using CQRS.Commands;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AppendFeedbackDetail
{
    public class AppendFeedbackDetailCommandHandler : ICommandHandler<AppendFeedbackDetailCommand>
    {
        private readonly IAppendFeedbackDetail appendFeedbackDetail;

        public AppendFeedbackDetailCommandHandler(IAppendFeedbackDetail appendFeedbackDetail)
        {
            this.appendFeedbackDetail = appendFeedbackDetail;
        }

        public void Handle(AppendFeedbackDetailCommand command)
        {
            this.appendFeedbackDetail.Append(command.FeedbackId, command.Text, command.User, command.Contacts);
        }
    }
}