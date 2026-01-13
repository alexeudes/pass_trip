using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pass_trip.Migrations
{
    public partial class PassportNumberOfDays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "numberOfDays",
                table: "Passports",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "numberOfDays",
                table: "Passports");
        }
    }
}
