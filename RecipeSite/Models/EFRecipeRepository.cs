using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeSite.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<RecipeItem> Recipes => context.Recipes;
        public IQueryable<Ingredient> Ingredients => context.Ingredients;
        public IQueryable<Equipment> Equipment => context.Equipment;
        public IQueryable<Review> Reviews => context.Reviews;

        public void AddRecipe(RecipeItem recipe)
        {
            context.AttachRange(recipe);
            context.SaveChanges();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            context.AttachRange(ingredient);
            context.SaveChanges();
        }

        public void AddEquipment(Equipment equipment)
        {
            context.AttachRange(equipment);
            context.SaveChanges();
        }

        public void AddReview(Review review)
        {
            context.AttachRange(review);
            context.SaveChanges();
        }

        public void SaveReview(Review review)
        {
            if (review.ReviewText == null)
            {
                context.Reviews.Add(review);
            }
            else
            {
                Review dbEntry = context.Reviews.FirstOrDefault(p => p.ReviewId == review.ReviewId);
                if (dbEntry != null)
                {
                    dbEntry.ReviewText = review.ReviewText;
                }
            }
            context.SaveChanges();
        }

        public void SaveRecipe(RecipeItem recipe)
        {
            RecipeItem dbEntry = context.Recipes.FirstOrDefault(p => p.RecipeId == recipe.RecipeId);
            if (dbEntry != null)
            {
                dbEntry.RecipeName = recipe.RecipeName;
                dbEntry.ServingSize = recipe.ServingSize;
                dbEntry.Description = recipe.Description;
                dbEntry.Instructions = recipe.Instructions;
            }
            context.SaveChanges();
        }

        public void SaveIngredient(Ingredient ingredient)
        {
            Ingredient dbEntry = context.Ingredients.FirstOrDefault(p => p.IngredientId == ingredient.IngredientId);
            if (dbEntry != null)
            {
                dbEntry.IngredientName = ingredient.IngredientName;
            }
            context.SaveChanges();
        }

        public void SaveEquipment(Equipment equipment)
        {
            Equipment dbEntry = context.Equipment.FirstOrDefault(p => p.EquipmentId == equipment.EquipmentId);
            if (dbEntry != null)
            {
                dbEntry.EquipmentName = equipment.EquipmentName;
            }
            context.SaveChanges();
        }

        public void DeleteRecipe(RecipeItem recipe)
        {
            RecipeItem dbEntry = context.Recipes.FirstOrDefault(p => p.RecipeId == recipe.RecipeId);
            if (dbEntry != null)
            {
                context.Recipes.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void DeleteReview(Review review)
        {
            Review dbEntry = context.Reviews.FirstOrDefault(p => p.ReviewId == review.ReviewId);
            if (dbEntry != null)
            {
                context.Reviews.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void DeleteIngredient(Ingredient ingredient)
        {
            Ingredient dbEntry = context.Ingredients.FirstOrDefault(p => p.IngredientId == ingredient.IngredientId);
            if (dbEntry != null)
            {
                context.Ingredients.Remove(dbEntry);
                context.SaveChanges();
            }
        }

        public void DeleteEquipment(Equipment equipment)
        {
            Equipment dbEntry = context.Equipment.FirstOrDefault(p => p.EquipmentId == equipment.EquipmentId);
            if (dbEntry != null)
            {
                context.Equipment.Remove(dbEntry);
                context.SaveChanges();
            }
        }
    }
}
