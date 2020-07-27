using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Core.Interfaces.IContext
{
    public interface IMongoDataBaseSettings
    {
        string CollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; } 

    }
}
