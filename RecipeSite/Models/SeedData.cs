using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RecipeSite.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(
                    new RecipeItem
                    {
                        RecipeName = "Chocolate Cake",
                        ServingSize = 10,
                        Description = "This is a Mexican chocolate cake.",
                        Instructions = "1. Add Flour.\n2. Mix with cake batter.\n3. Put in oven.\n4. Eat."
                    },
                    new RecipeItem
                    {
                        RecipeName = "Cake of Rice",
                        ServingSize = 5,
                        Description = "This is a Asian-style cake.",
                        Instructions = "1. Boil rice.\n2. Pour soy sauce with cake mixture.\n3. Deep fry.\n4. Eat."
                    },
                    new RecipeItem
                    {
                        RecipeName = "Rice of Balls",
                        ServingSize = 1,
                        Description = "These are rice balls.",
                        Instructions = "1. Boil rice.\n2. Roll rice into small balls.\n3. Eat."
                    }
                );
            }
            if (!context.Ingredients.Any())
            {
                context.Ingredients.AddRange(
                    new Ingredient
                    {
                        IngredientName = "Chocolate"
                    },
                    new Ingredient
                    {
                        IngredientName = "Rice"
                    },
                    new Ingredient
                    {
                        IngredientName = "Fried Rice"
                    }
                );
            }
            if (!context.Equipment.Any())
            {
                context.Equipment.AddRange(
                    new Equipment
                    {
                        EquipmentName = "Large Pan"
                    },
                    new Equipment
                    {
                        EquipmentName = "Pot"
                    },
                    new Equipment
                    {
                        EquipmentName = "Plate"
                    }
                );
            }
            if (!context.Reviews.Any())
            {
                context.Reviews.AddRange(
                    new Review
                    {
                        ReviewText = "10/10 Loved it."
                    },
                    new Review
                    {
                        ReviewText = "This sucks."
                    },
                    new Review
                    {
                        ReviewText = "I rather eat rice."
                    }
                );
            }
            context.SaveChanges();
        }
    }
}
