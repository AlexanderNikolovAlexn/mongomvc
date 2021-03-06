﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Author Name")]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "Length should be between {2} and {1}")]
        [DisplayName("Comment Body")]
        public string Text { get; set; }
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime DateCreated { get; set; }
    }
}