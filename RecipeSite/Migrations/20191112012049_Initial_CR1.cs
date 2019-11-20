using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RecipeSite.Migrations
{
    public partial class Initial_CR1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Equipment_EquipmentId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Ingredients_IngredientId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Reviews_ReviewId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_EquipmentId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IngredientId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ReviewId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "EquipmentId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Recipes");

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Reviews",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Ingredients",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Equipment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_RecipeId",
                table: "Equipment",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Recipes_RecipeId",
                table: "Equipment",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Recipes_RecipeId",
                table: "Reviews",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Recipes_RecipeId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Recipes_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Recipes_RecipeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_RecipeId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_RecipeId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Equipment");

            migrationBuilder.AddColumn<int>(
                name: "EquipmentId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReviewId",
                table: "Recipes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_EquipmentId",
                table: "Recipes",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IngredientId",
                table: "Recipes",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ReviewId",
                table: "Recipes",
                column: "ReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Equipment_EquipmentId",
                table: "Recipes",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Ingredients_IngredientId",
                table: "Recipes",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "IngredientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Reviews_ReviewId",
                table: "Recipes",
                column: "ReviewId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
