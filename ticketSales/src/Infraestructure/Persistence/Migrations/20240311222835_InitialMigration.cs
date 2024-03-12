using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EventLocationCountry = table.Column<string>(name: "EventLocation_Country", type: "nvarchar(3)", maxLength: 3, nullable: false),
                    EventLocationLine1 = table.Column<string>(name: "EventLocation_Line1", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EventLocationLine2 = table.Column<string>(name: "EventLocation_Line2", type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EventLocationCity = table.Column<string>(name: "EventLocation_City", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EventLocationState = table.Column<string>(name: "EventLocation_State", type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EventLocationZipCode = table.Column<string>(name: "EventLocation_ZipCode", type: "nvarchar(10)", maxLength: 10, nullable: true),
                    EventDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventCost = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EventActive = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
