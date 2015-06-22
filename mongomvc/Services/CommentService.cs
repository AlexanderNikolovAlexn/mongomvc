using MongoDB.Driver;
using MongoDB.Driver.Builders;
using mongomvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mongomvc.Services
{
    public class CommentService
    {
        private Connection con;

        public CommentService()
        {
            this.con = new Connection();
        }
        public bool Save(Comment comment)
        {            
            var comments = con.database.GetCollection("comments");
            comments.Insert(comment);
            con.Disconnect();
            return !String.IsNullOrEmpty(comment.CommentId);
        }

        public List<Comment> getList(String postId)
        {
            MongoCollection collection = con.database.GetCollection<Post>("comments");
            IMongoQuery query = Query.EQ("PostId", postId);
            MongoCursor<Comment> cursor = collection.FindAs<Comment>(query).SetSortOrder(SortBy.Descending("DateCreated"));
            var list = cursor.ToList();
            con.Disconnect();
            return list;

        }
    }
}