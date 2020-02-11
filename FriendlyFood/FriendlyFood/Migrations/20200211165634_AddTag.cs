using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class AddTag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RestaurantDiet_RestaurantId",
                table: "RestaurantDiet");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8b0e24f7-7f7c-45f4-895d-2c56d50f5d82", "AQAAAAEAACcQAAAAEA/yBO7qGHx8t6O3V8/NOySyoJ6lwiFSDQZSwMcpAO9VGGE7JWALH6aaG74kkiPdeA==" });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDiet_RestaurantId",
                table: "RestaurantDiet",
                column: "RestaurantId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_RestaurantDiet_RestaurantId",
                table: "RestaurantDiet");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44d9615c-6e8b-448f-aaa1-4a5c184a3698", "AQAAAAEAACcQAAAAECK8GvrmBLzoRJkOfFq6zzM9osY3JN9cK4yy/rll5VG4zWp7N7EDZ2kxf3h0o4GX/Q==" });

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantDiet_RestaurantId",
                table: "RestaurantDiet",
                column: "RestaurantId");
        }
    }
}
