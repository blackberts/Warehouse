using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyWorkersDeparments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentWorker");

            migrationBuilder.AddColumn<Guid>(
                name: "WorkersDepartmentsDepartmentId",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkersDepartmentsWorkerId",
                table: "Workers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkersDepartmentsDepartmentId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "WorkersDepartmentsWorkerId",
                table: "Departments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "WorkersDepartments",
                columns: table => new
                {
                    WorkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkersDepartments", x => new { x.WorkerId, x.DepartmentId });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Workers_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Workers",
                columns: new[] { "WorkersDepartmentsWorkerId", "WorkersDepartmentsDepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Departments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Departments",
                columns: new[] { "WorkersDepartmentsWorkerId", "WorkersDepartmentsDepartmentId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_WorkersDepartments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Departments",
                columns: new[] { "WorkersDepartmentsWorkerId", "WorkersDepartmentsDepartmentId" },
                principalTable: "WorkersDepartments",
                principalColumns: new[] { "WorkerId", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Workers_WorkersDepartments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Workers",
                columns: new[] { "WorkersDepartmentsWorkerId", "WorkersDepartmentsDepartmentId" },
                principalTable: "WorkersDepartments",
                principalColumns: new[] { "WorkerId", "DepartmentId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_WorkersDepartments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkersDepartments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Workers");

            migrationBuilder.DropTable(
                name: "WorkersDepartments");

            migrationBuilder.DropIndex(
                name: "IX_Workers_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Workers");

            migrationBuilder.DropIndex(
                name: "IX_Departments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "WorkersDepartmentsDepartmentId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkersDepartmentsWorkerId",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "WorkersDepartmentsDepartmentId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "WorkersDepartmentsWorkerId",
                table: "Departments");

            migrationBuilder.CreateTable(
                name: "DepartmentWorker",
                columns: table => new
                {
                    DepartmentsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentWorker", x => new { x.DepartmentsId, x.WorkersId });
                    table.ForeignKey(
                        name: "FK_DepartmentWorker_Departments_DepartmentsId",
                        column: x => x.DepartmentsId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentWorker_Workers_WorkersId",
                        column: x => x.WorkersId,
                        principalTable: "Workers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentWorker_WorkersId",
                table: "DepartmentWorker",
                column: "WorkersId");
        }
    }
}
