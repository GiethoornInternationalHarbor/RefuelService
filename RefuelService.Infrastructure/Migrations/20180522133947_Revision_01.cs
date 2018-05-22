using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace RefuelService.Infrastructure.Migrations
{
    public partial class Revision_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipService");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Ships");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Ships",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ShipService",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ShipId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipService_Ships_ShipId",
                        column: x => x.ShipId,
                        principalTable: "Ships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipService_ShipId",
                table: "ShipService",
                column: "ShipId");
        }
    }
}
