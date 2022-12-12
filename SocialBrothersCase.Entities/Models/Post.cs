using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialBrothersCase.Entities.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }
        
        public string? Content { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string? ImagePath { get; set; }
        public DateTime CreatedDate { get; set; } 
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }

    }
}
