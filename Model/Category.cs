using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace ExequteQuery.Models
{
    public class Category
    {
        [BsonId]
        public ObjectId id { get; set; }
        [Required(ErrorMessage ="please enter name parameter")]
        public string Name { get; set; }
        [Required(ErrorMessage ="please enter description parameter")]
        public string Description { get; set; }
    }
}