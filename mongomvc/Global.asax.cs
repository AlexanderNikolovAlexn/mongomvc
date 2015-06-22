using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MongoDB.Driver;
using MongoDB.Bson;
using mongomvc.App_Start;
using System.Web.Optimization;

namespace mongomvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(new BundleCollection());

            // Create database          
            CreateBlogDatabase();
        }

        private void CreateBlogDatabase()
        {
            // Create server settings to pass connection string, timeout, etc.
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer server = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var blog = server.GetDatabase("mongomvc");
            server.Disconnect();
        }

    }
}
