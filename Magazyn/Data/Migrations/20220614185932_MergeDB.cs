using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Magazyn.Data.Migrations
{
    public partial class MergeDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokacja",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    magazyn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    szafa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dzial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pomieszczenie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacja", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sprzet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SN = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    producent = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    osobaPrzypisana = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    lokalizacja = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    status = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    typ = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    osobaPrzypisanaID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprzet", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokacja");

            migrationBuilder.DropTable(
                name: "Sprzet");
        }
    }
}
