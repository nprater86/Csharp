﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chefs_n_dishes.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_CreatorChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_CreatorChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "CreatorChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "ChefId",
                table: "Dishes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes",
                column: "ChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes",
                column: "ChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Chefs_ChefId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_ChefId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "ChefId",
                table: "Dishes");

            migrationBuilder.AddColumn<int>(
                name: "CreatorChefId",
                table: "Dishes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CreatorChefId",
                table: "Dishes",
                column: "CreatorChefId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Chefs_CreatorChefId",
                table: "Dishes",
                column: "CreatorChefId",
                principalTable: "Chefs",
                principalColumn: "ChefId");
        }
    }
}
