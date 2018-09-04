using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace jannieCouture.Migrations
{
    public partial class updateProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeasurementCategorry",
                table: "ProductDetail",
                newName: "MeasurementCategory");

            migrationBuilder.AddColumn<int>(
                name: "MeasurementCategory",
                table: "Product",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeasurementCategory",
                table: "Product");

            migrationBuilder.RenameColumn(
                name: "MeasurementCategory",
                table: "ProductDetail",
                newName: "MeasurementCategorry");
        }
    }
}
