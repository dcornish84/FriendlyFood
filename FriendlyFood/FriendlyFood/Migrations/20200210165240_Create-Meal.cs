using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class CreateMeal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4689a973-6aa1-419d-9e0b-e06078f5c294", "AQAAAAEAACcQAAAAEOnI5oeLx7Y11MT2bJkESnDEZVmaBU1UBsxfluBTwHmRHzVevxovoAsvzt4gmXnc1w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f7b82e7a-0340-4ca3-9663-f607da4c79a5", "AQAAAAEAACcQAAAAECjhytUrKqE0jnUzr+syXobHHZ5tUJKEFhhgDasJwqDCICqLWvoCpN8NCD4iboTCIg==" });
        }
    }
}
