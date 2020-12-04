using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using System.Configuration;

namespace ExequteQuery.DAO
{
    public class MongoDbConnection
    {
        public MongoClient Client;
        public IMongoDatabase Database;
        public MongoDbConnection()
        {
            Client = new MongoClient(ConfigurationManager.ConnectionStrings["MongoDbConnectionString"].ConnectionString);
            Database = Client.GetDatabase("ComputerStore");

        }
    }
}