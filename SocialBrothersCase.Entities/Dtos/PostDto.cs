using Microsoft.AspNetCore.Http;
using SocialBrothersCase.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SocialBrothersCase.Entities.Dtos
{
    public class PostDto
    {
        public int? Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }
        [Required]
      
        public int? CategoryId { get; set; }
        public IFormFile? Image { get; set; }


        [JsonIgnore(Condition = JsonIgnoreCondition.Always)]


        public string? ImagePath { get; set; }


    }
}
