using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API
{
    public class CatalogOptions
    {
        public const string CatalogDbConnection = "CatalogDbConnection";

        public string ConnectionString { get; set; }
        public string Database { get; set; }
        public string ProductCollection { get; set; }
    }
}



