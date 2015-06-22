using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using mongomvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mongomvc.Services
{
    public static class PostService
    {
        public static bool Save(Post post)
        {
            // save the post into MongoDb
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer mongo = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var blog = mongo.GetDatabase("mongomvc");
            var posts = blog.GetCollection("posts");
            posts.Insert(post);
            mongo.Disconnect();
            return !String.IsNullOrEmpty(post.PostId);
        }

        public static Post GetById(String postId)
        {
            // save the post into MongoDb
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer mongo = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var blog = mongo.GetDatabase("mongomvc");
            IMongoQuery query = Query.EQ("_id", postId);
            var post = blog.GetCollection("posts").FindOneAs<Post>(query);
            mongo.Disconnect();            
            return post;

        }

        public static List<Post> GetList()
        {
            // save the post into MongoDb
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer mongo = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var blog = mongo.GetDatabase("mongomvc");
            MongoCollection collection = blog.GetCollection<Post>("posts");
            MongoCursor<Post> cursor = collection.FindAllAs<Post>();
            var list = cursor.ToList();
            mongo.Disconnect();
            return list;

        }

    }
}