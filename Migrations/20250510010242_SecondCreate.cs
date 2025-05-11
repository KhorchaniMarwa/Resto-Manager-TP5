using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestoManager_Marwa.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Restaurant",
                schema: "resto",
                table: "Restaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proprietaire",
                schema: "resto",
                table: "Proprietaire");

            migrationBuilder.EnsureSchema(
                name: "admin");

            migrationBuilder.RenameTable(
                name: "Restaurant",
                schema: "resto",
                newName: "TRestaurant",
                newSchema: "resto");

            migrationBuilder.RenameTable(
                name: "Proprietaire",
                schema: "resto",
                newName: "TProprietaire",
                newSchema: "resto");

            migrationBuilder.RenameIndex(
                name: "IX_Restaurant_NumProp",
                schema: "resto",
                table: "TRestaurant",
                newName: "IX_TRestaurant_NumProp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TRestaurant",
                schema: "resto",
                table: "TRestaurant",
                column: "CodeResto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TProprietaire",
                schema: "resto",
                table: "TProprietaire",
                column: "GsmProp");

            migrationBuilder.CreateTable(
                name: "TAvis",
                schema: "admin",
                columns: table => new
                {
                    CodeAvis = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomPersonne = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Note = table.Column<int>(type: "int", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NumResto = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAvis", x => x.CodeAvis);
                    table.ForeignKey(
                        name: "Relation_Resto_Avis",
                        column: x => x.NumResto,
                        principalSchema: "resto",
                        principalTable: "TRestaurant",
                        principalColumn: "CodeResto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TAvis_NumResto",
                schema: "admin",
                table: "TAvis",
                column: "NumResto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAvis",
                schema: "admin");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TRestaurant",
                schema: "resto",
                table: "TRestaurant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TProprietaire",
                schema: "resto",
                table: "TProprietaire");

            migrationBuilder.RenameTable(
                name: "TRestaurant",
                schema: "resto",
                newName: "Restaurant",
                newSchema: "resto");

            migrationBuilder.RenameTable(
                name: "TProprietaire",
                schema: "resto",
                newName: "Proprietaire",
                newSchema: "resto");

            migrationBuilder.RenameIndex(
                name: "IX_TRestaurant_NumProp",
                schema: "resto",
                table: "Restaurant",
                newName: "IX_Restaurant_NumProp");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Restaurant",
                schema: "resto",
                table: "Restaurant",
                column: "CodeResto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proprietaire",
                schema: "resto",
                table: "Proprietaire",
                column: "GsmProp");
        }
    }
}
