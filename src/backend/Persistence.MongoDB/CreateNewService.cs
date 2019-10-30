using DomainModel.Classes;
using DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.MongoDB
{
    internal class CreateNewService : ICreateNewService
    {
        private readonly DbContext dbContext;

        public CreateNewService(DbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public void Insert(Service service)
        {
            //dbContext.ServiceCollection.InsertOne(service);

            var collection = dbContext.ServiceCollection;

            collection.InsertOne(service);
        }
    }
}
