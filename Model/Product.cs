using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace ExequteQuery.Models
{
    public class Product
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [Required(ErrorMessage ="Please enter name attribute")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please select category")]
        public IEnumerable<Category> Categories { get; set; }
        [Required(ErrorMessage ="Please enter price")]
        public double Price { get; set; }
        
    }
}