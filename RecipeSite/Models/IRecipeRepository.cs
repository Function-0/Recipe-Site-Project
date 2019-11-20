using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public interface IRecipeRepository
    {
        IQueryable<RecipeItem> Recipes { get; }
        IQueryable<Ingredient> Ingredients { get; }
        IQueryable<Equipment> Equipment { get; }
        IQueryable<Review> Reviews { get; }

        void AddRecipe(RecipeItem recipe);
        void AddIngredient(Ingredient ingredient);
        void AddEquipment(Equipment equipment);
        void AddReview(Review review);
        void SaveReview(Review review);
        void SaveRecipe(RecipeItem recipe);
        void SaveIngredient(Ingredient ingredient);
        void SaveEquipment(Equipment equipment);
        void DeleteRecipe(RecipeItem recipe);
        void DeleteReview(Review review);
        void DeleteIngredient(Ingredient ingredient);
        void DeleteEquipment(Equipment equipment);
    }
}
