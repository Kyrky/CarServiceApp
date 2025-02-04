using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarServiceApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCarWithRepairCase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RepairCases_RepairCaseId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RepairCases_RepairCaseId1",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Cars_RepairCaseId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "RepairCaseId1",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "VIN",
                table: "Cars",
                newName: "Vin");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RepairCases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Cars",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RepairCases_RepairCaseId",
                table: "Cars",
                column: "RepairCaseId",
                principalTable: "RepairCases",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_RepairCases_RepairCaseId",
                table: "Cars");

            migrationBuilder.RenameColumn(
                name: "Vin",
                table: "Cars",
                newName: "VIN");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "RepairCases",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.UpdateData(
                table: "Cars",
                keyColumn: "PhotoPath",
                keyValue: null,
                column: "PhotoPath",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "PhotoPath",
                table: "Cars",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "RepairCaseId1",
                table: "Cars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_RepairCaseId1",
                table: "Cars",
                column: "RepairCaseId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RepairCases_RepairCaseId",
                table: "Cars",
                column: "RepairCaseId",
                principalTable: "RepairCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_RepairCases_RepairCaseId1",
                table: "Cars",
                column: "RepairCaseId1",
                principalTable: "RepairCases",
                principalColumn: "Id");
        }
    }
}
