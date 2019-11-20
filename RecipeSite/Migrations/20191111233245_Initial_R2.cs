using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RecipeSite.Migrations
{
    public partial class Initial_R2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Recipes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_EquipmentId",
                table: "Recipes",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IngredientId",
                table: "Recipes",
                column: "IngredientId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Equipment_EquipmentId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Ingredients_IngredientId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_EquipmentId",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_IngredientId",
                table: "Recipes");

            migrationBuilder.AlterColumn<int>(
                name: "IngredientId",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EquipmentId",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
