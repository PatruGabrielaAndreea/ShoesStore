using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoesStore.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    Id_Produs = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId_Brand = table.Column<int>(type: "int", nullable: true),
                    Id_Brand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.Id_Produs);
                    table.ForeignKey(
                        name: "FK_Produs_Brand_BrandId_Brand",
                        column: x => x.BrandId_Brand,
                        principalTable: "Brand",
                        principalColumn: "Id_Brand");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origine_User = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "CosCumparaturi",
                columns: table => new
                {
                    Id_Cos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    ProdusId_Produs = table.Column<int>(type: "int", nullable: true),
                    Id_Produs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosCumparaturi", x => x.Id_Cos);
                    table.ForeignKey(
                        name: "FK_CosCumparaturi_Produs_ProdusId_Produs",
                        column: x => x.ProdusId_Produs,
                        principalTable: "Produs",
                        principalColumn: "Id_Produs");
                });

            migrationBuilder.CreateTable(
                name: "Detalii_Produs",
                columns: table => new
                {
                    Id_Detalii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marime = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Culoare = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdusId_Produs = table.Column<int>(type: "int", nullable: true),
                    Id_Produs = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalii_Produs", x => x.Id_Detalii);
                    table.ForeignKey(
                        name: "FK_Detalii_Produs_Produs_ProdusId_Produs",
                        column: x => x.ProdusId_Produs,
                        principalTable: "Produs",
                        principalColumn: "Id_Produs");
                });

            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    Id_Comanda = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_Comenzii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Judet = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plata = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdusId_Produs = table.Column<int>(type: "int", nullable: true),
                    Id_Produs = table.Column<int>(type: "int", nullable: false),
                    UserId_User = table.Column<int>(type: "int", nullable: true),
                    Id_User = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.Id_Comanda);
                    table.ForeignKey(
                        name: "FK_Comanda_Produs_ProdusId_Produs",
                        column: x => x.ProdusId_Produs,
                        principalTable: "Produs",
                        principalColumn: "Id_Produs");
                    table.ForeignKey(
                        name: "FK_Comanda_User_UserId_User",
                        column: x => x.UserId_User,
                        principalTable: "User",
                        principalColumn: "Id_User");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_ProdusId_Produs",
                table: "Comanda",
                column: "ProdusId_Produs");

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_UserId_User",
                table: "Comanda",
                column: "UserId_User");

            migrationBuilder.CreateIndex(
                name: "IX_CosCumparaturi_ProdusId_Produs",
                table: "CosCumparaturi",
                column: "ProdusId_Produs");

            migrationBuilder.CreateIndex(
                name: "IX_Detalii_Produs_ProdusId_Produs",
                table: "Detalii_Produs",
                column: "ProdusId_Produs");

            migrationBuilder.CreateIndex(
                name: "IX_Produs_BrandId_Brand",
                table: "Produs",
                column: "BrandId_Brand");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "CosCumparaturi");

            migrationBuilder.DropTable(
                name: "Detalii_Produs");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
