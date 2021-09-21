using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conteiner",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cliente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Tipo = table.Column<short>(type: "smallint", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false),
                    Categoria = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conteiner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MovimentacaoCarga",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMovimentacao = table.Column<short>(type: "smallint", nullable: false),
                    Inicio = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Fim = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentacaoCarga", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conteiner");

            migrationBuilder.DropTable(
                name: "MovimentacaoCarga");
        }
    }
}
