using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Models
{
    public class Document
    {
        [BsonId] //to designate this property as the document's primary key
        [BsonRepresentation(BsonType.ObjectId)] //to allow passing the parameter as type string instead of an ObjectId structure. Mongo handles the conversion from string to ObjectId.
        public string DocumentId { get; set; }

        [BsonElement("Name")]//The attribute's value of Name represents the property name in the MongoDB collection.
        public string DocumentName { get; set; }

        public decimal Price { get; set; }

        public string Category { get; set; }

        public string Author { get; set; }
    }
}
