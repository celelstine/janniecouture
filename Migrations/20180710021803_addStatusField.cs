using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace jannieCouture.Migrations
{
    public partial class addStatusField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryID",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryID",
                table: "Product",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryID",
                table: "Product",
                column: "ProductCategoryID",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "status",
                table: "ProductCategory");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCategoryID",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductCategory_ProductCategoryID",
                table: "Product",
                column: "ProductCategoryID",
                principalTable: "ProductCategory",
                principalColumn: "ProductCategoryID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
