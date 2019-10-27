using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.CQRS.Commands.AppendFeedbackDetail
{
    public class AppendFeedbackDetailCommand
    {
        public string FeedbackId { get; set; }
        public string Text { get; set; }
        public string User { get; set; }
        public string Contacts { get; set; }
    }
}