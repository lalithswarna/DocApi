using DocApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Services
{
    public class DocumentService
    {

        private readonly IMongoCollection<Document> _documents;

        //an IDocumentstoreDatabaseSettings instance is retrieved from DI via constructor injection. 
        //This technique provides access to the appsettings.json configuration 
        //values that were added in the Add a configuration model section
        public DocumentService(IDocumentstoreDatabaseSettings settings)
        {
            //MongoClient: Reads the server instance for performing database operations. The constructor of this class is provided the MongoDB connection string
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _documents = database.GetCollection<Document>(settings.DocumentsCollectionName);
        }

        public List<Document> Get() =>
            _documents.Find(doc => true).ToList();

        public Document Get(string id) =>
            _documents.Find<Document>(doc => doc.DocumentId == id).FirstOrDefault();

        public Document Create(Document doc)
        {
            _documents.InsertOne(doc);
            return doc;
        }

        public void Update(string id, Document docIn) =>
            _documents.ReplaceOne(doc => doc.DocumentId == id, docIn);

        public void Remove(Document bookIn) =>
            _documents.DeleteOne(doc => doc.DocumentId == bookIn.DocumentId);

        public void Remove(string id) =>
            _documents.DeleteOne(book => book.DocumentId == id);
    }
}
