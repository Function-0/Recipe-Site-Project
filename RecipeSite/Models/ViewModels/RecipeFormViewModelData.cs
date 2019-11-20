using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeSite.Models.ViewModels
{
    public class RecipeFormViewModelData
    {
        public int RecipeId { get; set; }
        public string RecipeName { get; set; }
        public int ServingSize { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "A ingredient is required")]
        public string Ingredient { get; set; }
        [Required(ErrorMessage = "A equipment is required")]
        public string Equipment { get; set; }
        public string Review { get; set; }
        public string Instructions { get; set; }
    }
}
