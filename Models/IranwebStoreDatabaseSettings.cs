using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public interface IranwebStoreDatabaseSettings
    {
        string userCollectionName { get; set;}
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }
    }
}