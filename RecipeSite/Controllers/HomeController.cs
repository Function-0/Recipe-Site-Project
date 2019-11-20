using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeSite.Models;
using RecipeSite.Models.ViewModels;

namespace RecipeSite.Controllers
{
    public class HomeController : Controller
    {
        private RecipeItem defaultRecipe = new RecipeItem();

        private IRecipeRepository repository;

        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        
        public ViewResult Index()
        {
            return View();
        }

        [HttpGet]
        public ViewResult DisplayPage()
        {
            RecipeFormViewModelData recipeData = new RecipeFormViewModelData();
            return View(recipeData);
        }

        [HttpPost]
        public ViewResult DisplayPage(RecipeItem recipe)
        {
            int test = recipe.RecipeId;

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

        [HttpGet]
        public ViewResult InsertPage()
        {
            return View(new RecipeFormViewModelData());
        }

        [HttpPost]
        public ViewResult InsertPage(RecipeFormViewModelData recipe)
        {
            if (ModelState.IsValid)
            {
                RecipeItem newRecipe = new RecipeItem();
                newRecipe.RecipeName = recipe.RecipeName;
                newRecipe.ServingSize = recipe.ServingSize;
                newRecipe.Description = recipe.Description;
                Ingredient newIngredient = new Ingredient();
                newIngredient.IngredientName = recipe.Ingredient;
                Equipment newEquipment = new Equipment();
                newEquipment.EquipmentName = recipe.Equipment;
                newRecipe.Instructions = recipe.Instructions;

                repository.AddRecipe(newRecipe);
                repository.AddIngredient(newIngredient);
                repository.AddEquipment(newEquipment);
                repository.AddReview(new Review());
                return View("DataPage", repository.Recipes);
            }
            else
            {
                return View();
            }
            
        }

        public ViewResult DataPage()
        {
            return View(repository.Recipes);
        }

        public ViewResult UserPage()
        {
            return View(repository.Recipes);
        }


        public ViewResult ReviewInitial(RecipeItem recipe)
        {
            RecipeFormViewModelData recipeData = new RecipeFormViewModelData();
            recipeData.RecipeId = recipe.RecipeId;

            return View("Review", recipeData);
        }


        [HttpPost]
        public IActionResult Review(RecipeFormViewModelData recipeData)
        {
            Review newReview = new Review();
            newReview.ReviewText = recipeData.Review;
            newReview.ReviewId = recipeData.RecipeId;
            repository.SaveReview(newReview);
            RecipeItem currRecipe = new RecipeItem();
            currRecipe.RecipeId = recipeData.RecipeId;
            return RedirectToAction("UserPage");
        }


    }
}