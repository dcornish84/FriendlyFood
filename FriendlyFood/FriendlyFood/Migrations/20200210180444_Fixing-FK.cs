using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class FixingFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "45eddda3-ec9d-4974-a5fd-759b0c503656", "AQAAAAEAACcQAAAAEOxWqNOsBna+Zbg6RKIUTADxgU6AutTWpKBCE3bzkPSffwy788G29YGXlJFbvtnrsg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4689a973-6aa1-419d-9e0b-e06078f5c294", "AQAAAAEAACcQAAAAEOnI5oeLx7Y11MT2bJkESnDEZVmaBU1UBsxfluBTwHmRHzVevxovoAsvzt4gmXnc1w==" });
        }
    }
}
