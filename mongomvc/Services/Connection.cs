using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mongomvc.Services
{
    public class Connection
    {
        public MongoServer server;
        public MongoDatabase database;

        public Connection()
        {
            // save the post into MongoDb
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer mongo = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var conn = mongo.GetDatabase("mongomvc");
        }
        public MongoDatabase GetConnection()
        {
            return this.database;
        }

        public void Disconnect()
        {
            this.server.Disconnect();
        }
    }
}