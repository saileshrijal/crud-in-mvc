using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentViewModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentsDetails",
                table: "StudentsDetails");

            migrationBuilder.RenameTable(
                name: "StudentsDetails",
                newName: "StudentDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentDetails",
                table: "StudentDetails");

            migrationBuilder.RenameTable(
                name: "StudentDetails",
                newName: "StudentsDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentsDetails",
                table: "StudentsDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StudentViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Faculty = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentViewModel", x => x.Id);
                });
        }
    }
}
