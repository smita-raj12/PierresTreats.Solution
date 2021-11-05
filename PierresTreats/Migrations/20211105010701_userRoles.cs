using Microsoft.EntityFrameworkCore.Migrations;

namespace PierresTreats.Migrations
{
    public partial class userRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES (1,'Admin','ADMIN')");
          migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES (2,'Users','USERS')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = 1");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = 2");
        }
    }
}
