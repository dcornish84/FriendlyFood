using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class Favoritess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6139297-0d87-4501-87b9-8aae6f5d701c", "AQAAAAEAACcQAAAAELjpoIQh1RDQ4e+JP8QJ4dMtr3cxJWx6Pn0jls8HpOSL0uF+N8To4i3jbUWa4JNt7w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cb05a553-8b3c-4948-82cc-880c64ee21bf", "AQAAAAEAACcQAAAAEBzekUIGGtu6bLdySSgGKdm9ZX7VrnlO5Gwf5H3voiOriDK0idv/Czd1ch4o8+xv0A==" });
        }
    }
}
