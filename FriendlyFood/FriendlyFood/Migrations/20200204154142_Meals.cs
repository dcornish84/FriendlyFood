using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class Meals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "efd91fdd-e4bc-4aef-87ca-0d5ca6695e07", "AQAAAAEAACcQAAAAEN1P8ODn6+u0ic4WUIlO5mpOyilA98dM+DXDx2xyDPobNOeOu+ybX2jz+9fI2i2roA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_MealId",
                table: "Restaurant",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_RestaurantId",
                table: "Meal",
                column: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meal_Restaurant_RestaurantId",
                table: "Meal",
                column: "RestaurantId",
                principalTable: "Restaurant",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meal_Restaurant_RestaurantId",
                table: "Meal");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurant_Meal_MealId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Restaurant_MealId",
                table: "Restaurant");

            migrationBuilder.DropIndex(
                name: "IX_Meal_RestaurantId",
                table: "Meal");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "Restaurant");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d5142b3e-5a2a-4b63-97c6-f9431e891325", "AQAAAAEAACcQAAAAENEnB2MMkmcdCVN0b4rsVYXXMj1e2npsjNPxBeJ3vyXgfX31W8ucALvmPhao7O5Yew==" });
        }
    }
}
