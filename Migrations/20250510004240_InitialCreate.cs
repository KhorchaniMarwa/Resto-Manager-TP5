using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoManager_Marwa.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "resto");

            migrationBuilder.CreateTable(
                name: "Proprietaire",
                schema: "resto",
                columns: table => new
                {
                    GsmProp = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    NomProp = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmailProp = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proprietaire", x => x.GsmProp);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                schema: "resto",
                columns: table => new
                {
                    CodeResto = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomResto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    SpecResto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false, defaultValue: "Tunisienne"),
                    VilleResto = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TelResto = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    NumProp = table.Column<string>(type: "nvarchar(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.CodeResto);
                    table.ForeignKey(
                        name: "Relation_Proprio_Restos",
                        column: x => x.NumProp,
                        principalSchema: "resto",
                        principalTable: "Proprietaire",
                        principalColumn: "GsmProp",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_NumProp",
                schema: "resto",
                table: "Restaurant",
                column: "NumProp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurant",
                schema: "resto");

            migrationBuilder.DropTable(
                name: "Proprietaire",
                schema: "resto");
        }
    }
}
