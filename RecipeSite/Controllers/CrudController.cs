using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;


namespace RecipeSite.Controllers
{
    public class CrudController : Controller
    {
        private IRecipeRepository repository;

        public CrudController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public IActionResult DeleteData(RecipeFormViewModelData recipe) 
        {
            RecipeItem newRecipe = new RecipeItem();
            newRecipe.RecipeName = recipe.RecipeName;
            newRecipe.ServingSize = recipe.ServingSize;
            newRecipe.Description = recipe.Description;
            newRecipe.RecipeId = recipe.RecipeId;
            Ingredient newIngredient = new Ingredient();
            newIngredient.IngredientName = recipe.Ingredient;
            newIngredient.IngredientId = recipe.RecipeId;
            Equipment newEquipment = new Equipment();
            newEquipment.EquipmentName = recipe.Equipment;
            newEquipment.EquipmentId = recipe.RecipeId;
            newRecipe.Instructions = recipe.Instructions;
            Review newReview = new Review();
            newReview.ReviewText = recipe.Review;
            newReview.ReviewId = recipe.RecipeId;

            repository.DeleteRecipe(newRecipe);
            repository.DeleteReview(newReview);
            repository.DeleteIngredient(newIngredient);
            repository.DeleteEquipment(newEquipment);

            return RedirectToAction("DataPage", "Home");
        }

        [HttpPost]
        public IActionResult Delete(RecipeItem recipe)
        {
            var test = recipe;
            RecipeFormViewModel recipeData = new RecipeFormViewModel();
            recipeData.Recipe = repository.Recipes.Where(r => r.RecipeId == recipe.RecipeId).FirstOrDefault<RecipeItem>();
            recipeData.Equipment = repository.Equipment.Where(r => r.EquipmentId == recipe.RecipeId).FirstOrDefault<Equipment>();
            recipeData.Ingredient = repository.Ingredients.Where(r => r.IngredientId == recipe.RecipeId).FirstOrDefault<Ingredient>();
            recipeData.Review = repository.Reviews.Where(r => r.ReviewId == recipe.RecipeId).FirstOrDefault<Review>();

            RecipeFormViewModelData recipeDataOutput = new RecipeFormViewModelData();
            recipeDataOutput.RecipeId = recipeData.Recipe.RecipeId;
            recipeDataOutput.RecipeName = recipeData?.Recipe?.RecipeName;
            recipeDataOutput.ServingSize = recipeData.Recipe.ServingSize;
            recipeDataOutput.Description = recipeData?.Recipe?.Description;
            recipeDataOutput.Ingredient = recipeData?.Ingredient?.IngredientName;
            recipeDataOutput.Equipment = recipeData?.Equipment?.EquipmentName;
            recipeDataOutput.Review = recipeData?.Review?.ReviewText;
            recipeDataOutput.Instructions = recipeData?.Recipe?.Instructions;

            return RedirectToAction("DeleteData", "Crud", recipeDataOutput);
        }

        [HttpPost]
        public ViewResult Edit(RecipeItem recipe)
        {
            RecipeFormViewModel recipeData = new RecipeFormViewModel();
            recipeData.Recipe = repository.Recipes.Where(r => r.RecipeId == recipe.RecipeId).FirstOrDefault<RecipeItem>();
            recipeData.Equipment = repository.Equipment.Where(r => r.EquipmentId == recipe.RecipeId).FirstOrDefault<Equipment>();
            recipeData.Ingredient = repository.Ingredients.Where(r => r.IngredientId == recipe.RecipeId).FirstOrDefault<Ingredient>();
            recipeData.Review = repository.Reviews.Where(r => r.ReviewId == recipe.RecipeId).FirstOrDefault<Review>();

            RecipeFormViewModelData recipeDataOutput = new RecipeFormViewModelData();
            recipeDataOutput.RecipeId = recipeData.Recipe.RecipeId;
            recipeDataOutput.RecipeName = recipeData?.Recipe?.RecipeName;
            recipeDataOutput.ServingSize = recipeData.Recipe.ServingSize;
            recipeDataOutput.Description = recipeData?.Recipe?.Description;
            recipeDataOutput.Ingredient = recipeData?.Ingredient?.IngredientName;
            recipeDataOutput.Equipment = recipeData?.Equipment?.EquipmentName;
            recipeDataOutput.Review = recipeData?.Review?.ReviewText;
            recipeDataOutput.Instructions = recipeData?.Recipe?.Instructions;

            return View(recipeDataOutput);
        }

        [HttpPost]
        public IActionResult InsertPage(RecipeFormViewModelData recipe)
        {
            RecipeItem newRecipe = new RecipeItem();
            newRecipe.RecipeName = recipe.RecipeName;
            newRecipe.ServingSize = recipe.ServingSize;
            newRecipe.Description = recipe.Description;
            newRecipe.RecipeId = recipe.RecipeId;
            Ingredient newIngredient = new Ingredient();
            newIngredient.IngredientName = recipe.Ingredient;
            newIngredient.IngredientId = recipe.RecipeId;
            Equipment newEquipment = new Equipment();
            newEquipment.EquipmentName = recipe.Equipment;
            newEquipment.EquipmentId = recipe.RecipeId;
            newRecipe.Instructions = recipe.Instructions;
            Review newReview = new Review();
            newReview.ReviewText = recipe.Review;
            newReview.ReviewId = recipe.RecipeId;

            repository.SaveRecipe(newRecipe);
            repository.SaveIngredient(newIngredient);
            repository.SaveEquipment(newEquipment);
            repository.SaveReview(newReview);

            return RedirectToAction("DataPage", "Home");
        }

        //[HttpPost]
        //public ViewResult Edit(RecipeItem recipe)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        repository.SaveRecipe(recipes);
        //        TempData["message"] = $"{recipes.DishName} has been saved";
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        return View(recipes);
        //    }
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}