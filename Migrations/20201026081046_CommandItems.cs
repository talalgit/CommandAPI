using Microsoft.EntityFrameworkCore.Migrations;

namespace CommandAPI.Migrations
{
    public partial class CommandItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommandsItems",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HowTo = table.Column<string>(maxLength: 250, nullable: false),
                    Platform = table.Column<string>(nullable: false),
                    CommandLine = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandsItems", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommandsItems");
        }
    }
}
