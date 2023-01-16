using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyWorkersDeparments2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_WorkersDepartments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Workers_WorkersDepartments_WorkersDepartmentsWorkerId_WorkersDepartmentsDepartmentId",
                table: "Workers");

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkersDepartments_DepartmentId",
                table: "WorkersDepartments",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkersDepartments_Departments_DepartmentId",
                table: "WorkersDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkersDepartments_Workers_WorkerId",
                table: "WorkersDepartments",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkersDepartments_Departments_DepartmentId",
                table: "WorkersDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkersDepartments_Workers_WorkerId",
                table: "WorkersDepartments");

            migrationBuilder.DropIndex(
                name: "IX_WorkersDepartments_DepartmentId",
                table: "WorkersDepartments");

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
    }
}
