using Microsoft.EntityFrameworkCore.Migrations;

namespace backend.Migrations
{
    public partial class CreateMachinePiece : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tPiece",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tPiece", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tMachinePiece",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    machineId = table.Column<int>(type: "INTEGER", nullable: false),
                    pieceId = table.Column<int>(type: "INTEGER", nullable: false),
                    amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tMachinePiece", x => x.id);
                    table.ForeignKey(
                        name: "FK_tMachinePiece_tMachine_machineId",
                        column: x => x.machineId,
                        principalTable: "tMachine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tMachinePiece_tPiece_pieceId",
                        column: x => x.pieceId,
                        principalTable: "tPiece",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tMachinePiece_machineId",
                table: "tMachinePiece",
                column: "machineId");

            migrationBuilder.CreateIndex(
                name: "IX_tMachinePiece_pieceId",
                table: "tMachinePiece",
                column: "pieceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tMachinePiece");

            migrationBuilder.DropTable(
                name: "tPiece");
        }
    }
}
