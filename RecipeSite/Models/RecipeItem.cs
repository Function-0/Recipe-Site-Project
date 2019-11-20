using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeSite.Models
{
    public class RecipeItem
    {
        [Key]
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int ServingSize { get; set; }
        public string Description { get; set; }
        //public Ingredient Ingredient { get; set; }
        //public Equipment Equipment { get; set; }
        //public Review Review { get; set; }
        public string Instructions { get; set; }
    }
}
