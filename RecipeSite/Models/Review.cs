using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeSite.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public RecipeItem Recipe { get; set; }
    }
}
