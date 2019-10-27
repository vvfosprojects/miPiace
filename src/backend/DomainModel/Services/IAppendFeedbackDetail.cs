using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IAppendFeedbackDetail
    {
        void Append(string feedbackId, string text, string user, string contacts);
    }
}