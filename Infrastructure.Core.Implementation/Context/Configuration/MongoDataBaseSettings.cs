using Infrastructure.Core.Interfaces.IContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Core.Implementation.Context
{
    public class MongoDataBaseSettings : IMongoDataBaseSettings
    {
        public string CollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
