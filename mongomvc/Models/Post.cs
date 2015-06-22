using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mongomvc.Models
{
    public class Post
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public String PostId { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Length should be between {2} and {1}")]
        public string Title { get; set; }
        [Required]
        [StringLength(4000, MinimumLength = 3, ErrorMessage = "Length should be between {2} and {1}")]
        public string Body { get; set; }
        public DateTime DateCreated { get; set; }
     }
}