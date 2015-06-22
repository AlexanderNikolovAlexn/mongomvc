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
    public class PostService
    {
        private Connection con;

        public PostService()
        {
            this.con = new Connection();
        }
        public bool Save(Post post)
        {
            var posts = con.database.GetCollection("posts");
            posts.Insert(post);
            con.Disconnect();
            return !String.IsNullOrEmpty(post.PostId);
        }

        public Post GetById(String postId)
        {
            IMongoQuery query = Query.EQ("_id", postId);
            var post = con.database.GetCollection("posts").FindOneAs<Post>(query);
            con.Disconnect();            
            return post;

        }

        public List<Post> GetList()
        {
            MongoCollection collection = con.database.GetCollection<Post>("posts");
            MongoCursor<Post> cursor = collection.FindAllAs<Post>().SetSortOrder(SortBy.Descending("DateCreated"));
            var list = cursor.ToList();
            con.Disconnect();
            return list;

        }

    }
}