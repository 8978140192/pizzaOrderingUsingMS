using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaApi.Migrations
{
    public partial class initi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PizzaDetails",
                columns: table => new
                {
                    PizzaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PizzaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaPrice = table.Column<double>(type: "float", nullable: false),
                    PizzaDiscription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PizzaType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaDetails", x => x.PizzaId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaDetails");
        }
    }
}
