using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class DietTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44d9615c-6e8b-448f-aaa1-4a5c184a3698", "AQAAAAEAACcQAAAAECK8GvrmBLzoRJkOfFq6zzM9osY3JN9cK4yy/rll5VG4zWp7N7EDZ2kxf3h0o4GX/Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b747371a-af46-4c8b-93ba-219406d8772e", "AQAAAAEAACcQAAAAEMaaZMIzvjLNJsNYgPPOhuTXiCveWv+38Ocd3fuo8trILV/THIN076pkSbrXy1QEjg==" });
        }
    }
}
