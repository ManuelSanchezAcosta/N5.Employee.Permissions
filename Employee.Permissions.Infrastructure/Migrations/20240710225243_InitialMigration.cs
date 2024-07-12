using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Permissions.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    IdEmployee = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdEmployee", x => x.IdEmployee);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    IdPermission = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdEmployee = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdPermissionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    User = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPermission", x => x.IdPermission);
                });

            migrationBuilder.CreateTable(
                name: "PermissionTypes",
                columns: table => new
                {
                    IdPermissionType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    User = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdPermissionType", x => x.IdPermissionType);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Email",
                table: "Employees",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionTypes_Description",
                table: "PermissionTypes",
                column: "Description",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PermissionTypes");
        }
    }
}
