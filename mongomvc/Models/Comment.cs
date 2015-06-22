using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mongomvc.Models
{
    public class Comment
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public String CommentId { get; set; }
        
        public String PostId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length should be between {2} and {1}")]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "Length should be between {2} and {1}")]
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}