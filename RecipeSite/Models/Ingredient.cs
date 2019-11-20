using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeSite.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public RecipeItem Recipe { get; set; }
    }
}
