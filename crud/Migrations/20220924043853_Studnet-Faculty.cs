﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace crud.Migrations
{
    public partial class StudnetFaculty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Faculty",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FacultyName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faculty");

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
    }
}