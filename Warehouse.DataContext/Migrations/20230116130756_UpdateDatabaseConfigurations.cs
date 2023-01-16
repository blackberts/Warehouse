using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Warehouse.DataContext.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseConfigurations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkersDepartments_Departments_DepartmentId",
                table: "WorkersDepartments");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkersDepartments_Workers_WorkerId",
                table: "WorkersDepartments");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkersDepartments_Departments_DepartmentId",
                table: "WorkersDepartments",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkersDepartments_Workers_WorkerId",
                table: "WorkersDepartments",
                column: "WorkerId",
                principalTable: "Workers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
    }
}
