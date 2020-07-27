using Domain.Core.DTO;
using Infrastructure.Core.Interfaces.IContext;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Core.Implementation.Context
{
    public class ContextDb: IContextDb
    {
        private readonly IMongoCollection<Ordenes> _OrdenesCollection;

        public ContextDb(IMongoDataBaseSettings settings) {

            var mdbClient = new MongoClient(settings.ConnectionString);
            var database = mdbClient.GetDatabase(settings.DatabaseName);

            _OrdenesCollection = database.GetCollection<Ordenes>(settings.CollectionName);
        }

        public Ordenes Create(Ordenes book)
        {
            _OrdenesCollection.InsertOne(book);
            return book;
        }

        public void Delete(Ordenes orden)
        {
            _OrdenesCollection.DeleteOne(x => x.Order_MDB_Id == orden.Order_MDB_Id);
        }

        public void DeleteById(string id)
        {
            _OrdenesCollection.DeleteOne(x => x.Order_MDB_Id == id);
        }

        public List<Ordenes> Get()
        {
            return _OrdenesCollection.Find(book => true).ToList();
        }

        public Ordenes GetById(string id)
        {
            return _OrdenesCollection.Find<Ordenes>(ordenes => ordenes.Order_MDB_Id == id).FirstOrDefault();
        }

        public void Update(string id, Ordenes orden)
        {
            _OrdenesCollection.ReplaceOne(x => x.Order_MDB_Id == id, orden);
        }
    }
}
