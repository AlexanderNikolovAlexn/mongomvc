using MongoDB.Driver;
using MongoDB.Driver.Builders;
using mongomvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mongomvc.Services
{
    public static class CommentService
    {
        public static bool Save(Comment comment)
        {
            // save the post into MongoDb
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer mongo = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var blog = mongo.GetDatabase("mongomvc");
            var comments = blog.GetCollection("comments");
            comments.Insert(comment);
            mongo.Disconnect();
            return !String.IsNullOrEmpty(comment.CommentId);
        }

        public static List<Comment> getList(String postId)
        {
            // save the post into MongoDb
            MongoServerSettings settings = new MongoServerSettings();
            settings.Server = new MongoServerAddress("localhost", 27017);
            // Create server object to communicate with our server
            MongoServer mongo = new MongoServer(settings);
            // Get our database instance to reach collections and data
            var blog = mongo.GetDatabase("mongomvc");

            MongoCollection collection = blog.GetCollection<Post>("comments");
            IMongoQuery query = Query.EQ("PostId", postId);
            MongoCursor<Comment> cursor = collection.FindAs<Comment>(query);
            var list = cursor.ToList();
            mongo.Disconnect();
            return list;

        }
    }
}