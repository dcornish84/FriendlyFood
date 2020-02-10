using Microsoft.EntityFrameworkCore.Migrations;

namespace FriendlyFood.Migrations
{
    public partial class DeleteFaves : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f7b82e7a-0340-4ca3-9663-f607da4c79a5", "AQAAAAEAACcQAAAAECjhytUrKqE0jnUzr+syXobHHZ5tUJKEFhhgDasJwqDCICqLWvoCpN8NCD4iboTCIg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "00000000-ffff-ffff-ffff-ffffffffffff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44695e22-6cab-4cd2-ae3b-657fb61dee24", "AQAAAAEAACcQAAAAEFRI8OmgjifkZ98+/AoQhAc+OUynP3bFpoT+DOXEAx/H6UlvWyZlFkw3fKsWeDNmtQ==" });
        }
    }
}
