using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeSite.Models;

namespace RecipeSite.Models.ViewModels
{
    public class RecipeFormViewModel
    {
        public RecipeItem Recipe { get; set; }
        public Ingredient Ingredient { get; set; }
        public Equipment Equipment { get; set; }
        public Review Review { get; set; }
        
    }
}
