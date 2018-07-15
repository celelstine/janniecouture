using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace jannieCouture.Migrations
{
    public partial class fixProductDetailPriceRelationship1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPrice_ProductDetailPriceHistory_ProductDetailPriceHistoryId",
                table: "ProductDetailPrice");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetailPrice_ProductDetailPriceHistoryId",
                table: "ProductDetailPrice");

            migrationBuilder.DropColumn(
                name: "ProductDetailPriceHistoryId",
                table: "ProductDetailPrice");

            migrationBuilder.AddColumn<int>(
                name: "ProductDetailPriceId1",
                table: "ProductDetailPriceHistory",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailPriceHistory_ProductDetailPriceId1",
                table: "ProductDetailPriceHistory",
                column: "ProductDetailPriceId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPriceHistory_ProductDetailPrice_ProductDetailPriceId1",
                table: "ProductDetailPriceHistory",
                column: "ProductDetailPriceId1",
                principalTable: "ProductDetailPrice",
                principalColumn: "ProductDetailPriceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductDetailPriceHistory_ProductDetailPrice_ProductDetailPriceId1",
                table: "ProductDetailPriceHistory");

            migrationBuilder.DropIndex(
                name: "IX_ProductDetailPriceHistory_ProductDetailPriceId1",
                table: "ProductDetailPriceHistory");

            migrationBuilder.DropColumn(
                name: "ProductDetailPriceId1",
                table: "ProductDetailPriceHistory");

            migrationBuilder.AddColumn<int>(
                name: "ProductDetailPriceHistoryId",
                table: "ProductDetailPrice",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductDetailPrice_ProductDetailPriceHistoryId",
                table: "ProductDetailPrice",
                column: "ProductDetailPriceHistoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductDetailPrice_ProductDetailPriceHistory_ProductDetailPriceHistoryId",
                table: "ProductDetailPrice",
                column: "ProductDetailPriceHistoryId",
                principalTable: "ProductDetailPriceHistory",
                principalColumn: "ProductDetailPriceHistoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
