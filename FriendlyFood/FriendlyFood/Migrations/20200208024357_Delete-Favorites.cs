using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class DeleteFavorites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuisine_Restaurant_RestaurantId",
                table: "Cuisine");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoritRestaurant_Restaurant_RestaurantId",
                table: "FavoritRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Restaurant_RestaurantId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_AspNetUsers_ApplicationUserId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Cuisine_CuisineId",
                table: "Restaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Meal_MealId",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                newName: "FavoriteRestaurant");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_MealId",
                table: "FavoriteRestaurant",
                newName: "IX_FavoriteRestaurant_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_CuisineId",
                table: "FavoriteRestaurant",
                newName: "IX_FavoriteRestaurant_CuisineId");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_ApplicationUserId",
                table: "FavoriteRestaurant",
                newName: "IX_FavoriteRestaurant_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteRestaurant",
                table: "FavoriteRestaurant",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44695e22-6cab-4cd2-ae3b-657fb61dee24", "AQAAAAEAACcQAAAAEFRI8OmgjifkZ98+/AoQhAc+OUynP3bFpoT+DOXEAx/H6UlvWyZlFkw3fKsWeDNmtQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDiet_DietTypeId",
                table: "RestaurantDiet",
                column: "DietTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDiet_RestaurantId",
                table: "RestaurantDiet",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_MealDiet_DietTypeId",
                table: "MealDiet",
                column: "DietTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_MealDiet_MealId",
                table: "MealDiet",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuisine_FavoriteRestaurant_RestaurantId",
                table: "Cuisine",
                column: "RestaurantId",
                principalTable: "FavoriteRestaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRestaurant_AspNetUsers_ApplicationUserId",
                table: "FavoriteRestaurant",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRestaurant_Cuisine_CuisineId",
                table: "FavoriteRestaurant",
                column: "CuisineId",
                principalTable: "Cuisine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteRestaurant_Meal_MealId",
                table: "FavoriteRestaurant",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritRestaurant_FavoriteRestaurant_RestaurantId",
                table: "FavoritRestaurant",
                column: "RestaurantId",
                principalTable: "FavoriteRestaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_FavoriteRestaurant_RestaurantId",
                table: "Meal",
                column: "RestaurantId",
                principalTable: "FavoriteRestaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealDiet_DietType_DietTypeId",
                table: "MealDiet",
                column: "DietTypeId",
                principalTable: "DietType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealDiet_Meal_MealId",
                table: "MealDiet",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantDiet_DietType_DietTypeId",
                table: "RestaurantDiet",
                column: "DietTypeId",
                principalTable: "DietType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RestaurantDiet_FavoriteRestaurant_RestaurantId",
                table: "RestaurantDiet",
                column: "RestaurantId",
                principalTable: "FavoriteRestaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuisine_FavoriteRestaurant_RestaurantId",
                table: "Cuisine");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRestaurant_AspNetUsers_ApplicationUserId",
                table: "FavoriteRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRestaurant_Cuisine_CuisineId",
                table: "FavoriteRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteRestaurant_Meal_MealId",
                table: "FavoriteRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoritRestaurant_FavoriteRestaurant_RestaurantId",
                table: "FavoritRestaurant");

            migrationBuilder.DropForeignKey(
                name: "FK_Meal_FavoriteRestaurant_RestaurantId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiet_DietType_DietTypeId",
                table: "MealDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_MealDiet_Meal_MealId",
                table: "MealDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantDiet_DietType_DietTypeId",
                table: "RestaurantDiet");

            migrationBuilder.DropForeignKey(
                name: "FK_RestaurantDiet_FavoriteRestaurant_RestaurantId",
                table: "RestaurantDiet");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantDiet_DietTypeId",
                table: "RestaurantDiet");

            migrationBuilder.DropIndex(
                name: "IX_RestaurantDiet_RestaurantId",
                table: "RestaurantDiet");

            migrationBuilder.DropIndex(
                name: "IX_MealDiet_DietTypeId",
                table: "MealDiet");

            migrationBuilder.DropIndex(
                name: "IX_MealDiet_MealId",
                table: "MealDiet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteRestaurant",
                table: "FavoriteRestaurant");

            migrationBuilder.RenameTable(
                name: "FavoriteRestaurant",
                newName: "Restaurant");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteRestaurant_MealId",
                table: "Restaurant",
                newName: "IX_Restaurant_MealId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteRestaurant_CuisineId",
                table: "Restaurant",
                newName: "IX_Restaurant_CuisineId");

            migrationBuilder.RenameIndex(
                name: "IX_FavoriteRestaurant_ApplicationUserId",
                table: "Restaurant",
                newName: "IX_Restaurant_ApplicationUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                table: "Restaurant",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6139297-0d87-4501-87b9-8aae6f5d701c", "AQAAAAEAACcQAAAAELjpoIQh1RDQ4e+JP8QJ4dMtr3cxJWx6Pn0jls8HpOSL0uF+N8To4i3jbUWa4JNt7w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Cuisine_Restaurant_RestaurantId",
                table: "Cuisine",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoritRestaurant_Restaurant_RestaurantId",
                table: "FavoritRestaurant",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Restaurant_RestaurantId",
                table: "Meal",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_AspNetUsers_ApplicationUserId",
                table: "Restaurant",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Cuisine_CuisineId",
                table: "Restaurant",
                column: "CuisineId",
                principalTable: "Cuisine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurant_Meal_MealId",
                table: "Restaurant",
                column: "MealId",
                principalTable: "Meal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
