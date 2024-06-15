using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiendas.Migrations
{
    /// <inheritdoc />
    public partial class CrearRelacionProductoCategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Sucursales",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoriaId",
                table: "Categorias",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sucursales_CategoriaId",
                table: "Sucursales",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_CategoriaId",
                table: "Categorias",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categorias_Categorias_CategoriaId",
                table: "Categorias",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sucursales_Categorias_CategoriaId",
                table: "Sucursales",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categorias_Categorias_CategoriaId",
                table: "Categorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Sucursales_Categorias_CategoriaId",
                table: "Sucursales");

            migrationBuilder.DropIndex(
                name: "IX_Sucursales_CategoriaId",
                table: "Sucursales");

            migrationBuilder.DropIndex(
                name: "IX_Categorias_CategoriaId",
                table: "Categorias");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Sucursales");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Categorias");
        }
    }
}
