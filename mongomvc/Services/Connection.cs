using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mongomvc.Services
{
    public class Connection
    {
        public MongoServer server { get; }
        public MongoDatabase database { get; }

        public Connection()
        {
            // save the post into MongoDb
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            this.server = new MongoServer(settings);
            // Get our database instance to reach collections and data
            this.database = this.server.GetDatabase("mongomvc");
        }

        public void Disconnect()
        {
            this.server.Disconnect();
        }
    }
}