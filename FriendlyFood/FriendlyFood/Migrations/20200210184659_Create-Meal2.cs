using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class CreateMeal2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b747371a-af46-4c8b-93ba-219406d8772e", "AQAAAAEAACcQAAAAEMaaZMIzvjLNJsNYgPPOhuTXiCveWv+38Ocd3fuo8trILV/THIN076pkSbrXy1QEjg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45eddda3-ec9d-4974-a5fd-759b0c503656", "AQAAAAEAACcQAAAAEOxWqNOsBna+Zbg6RKIUTADxgU6AutTWpKBCE3bzkPSffwy788G29YGXlJFbvtnrsg==" });
        }
    }
}
