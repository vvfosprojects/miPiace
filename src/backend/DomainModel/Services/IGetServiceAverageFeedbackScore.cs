using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Services
{
    public interface IGetServiceAverageFeedbackScore
    {
        Dictionary<string,double> Get(string privateToken);
    }
}
