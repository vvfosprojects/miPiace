using System;
using Microsoft.Extensions.Configuration;
using SimpleInjector;

namespace CompositionRoot
{
    /// <summary>
    /// This class contains all the custom application bindings.
    /// </summary>
    internal static class CustomBindings
    {
        internal static void Bind(Container container, IConfiguration configuration)
        {
            container.Register<Persistence.MongoDB.DbContext>(() =>
            {
                var configurationString = configuration.GetSection("ConnectionString").Value;
                var databaseName = configuration.GetSection("DatabaseName").Value;
                return new Persistence.MongoDB.DbContext(configurationString, databaseName);
            }, Lifestyle.Singleton);

            container.Register<DomainModel.Services.ISaveRating, Persistence.MongoDB.SaveRating>();
            container.Register<DomainModel.Services.IAppendFeedbackDetail, Persistence.MongoDB.AppendFeedbackDetail>();
            container.Register<DomainModel.Services.ICreateNewService, Persistence.MongoDB.CreateNewService>();
            container.Register<DomainModel.Services.IGetWelcomeMessageByPublicToken, Persistence.MongoDB.GetWelcomeMessageByPublicToken>();
            container.Register<DomainModel.Services.IGetServiceAverageFeedbackScore, Persistence.MongoDB.GetServiceAverageFeedbackScore>();
            container.Register<DomainModel.Services.IGetFeedback, Persistence.MongoDB.GetFeedback>();
        }
    }
}