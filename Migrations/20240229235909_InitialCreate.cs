using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace pass_trip.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "TEXT", nullable: false),
                    origin = table.Column<string>(type: "TEXT", nullable: false),
                    destination = table.Column<string>(type: "TEXT", nullable: false),
                    requirement = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passports");
        }
    }
}
