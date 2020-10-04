using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocApi.Models
{
    //this class is used to store the appsettings.json file's DocumentstoreDatabaseSettings property values. 
    //The JSON and C# property names are named identically to ease the mapping process.
    public class DocumentstoreDatabaseSettings  : IDocumentstoreDatabaseSettings
        {
            public string DocumentsCollectionName { get; set; }
            public string ConnectionString { get; set; }
            public string DatabaseName { get; set; }
        }

    public interface IDocumentstoreDatabaseSettings
    {
        string DocumentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
