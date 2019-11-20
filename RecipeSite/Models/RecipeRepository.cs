using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class RecipeRepository
    {
        private static List<RecipeItem> recipes = new List<RecipeItem>();

        public static IEnumerable<RecipeItem> Recipes
        {
            get
            {
                return recipes;
            }
        }

        public static void AddRecipe(RecipeItem recipe) 
        {
            recipes.Add(recipe);
        }

        public static RecipeItem GetRecipe(int recipeId)
        {
            return recipes[recipeId];
        }
    }
}
