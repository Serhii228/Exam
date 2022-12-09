using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Priority", "Status", "Text", "Time" },
                values: new object[,]
                {
                    { 1, 0, 0, "Add feature1.", new DateTime(2022, 12, 9, 12, 31, 1, 354, DateTimeKind.Local).AddTicks(6182) },
                    { 2, 1, 1, "Add feature2.", new DateTime(2022, 12, 9, 12, 31, 1, 356, DateTimeKind.Local).AddTicks(8086) },
                    { 3, 2, 2, "Add task1.", new DateTime(2022, 12, 9, 12, 31, 1, 356, DateTimeKind.Local).AddTicks(8117) },
                    { 4, 0, 3, "Add task2.", new DateTime(2022, 12, 9, 12, 31, 1, 356, DateTimeKind.Local).AddTicks(8121) },
                    { 5, 2, 0, "Fix bug1.", new DateTime(2022, 12, 9, 12, 31, 1, 356, DateTimeKind.Local).AddTicks(8124) },
                    { 6, 0, 3, "Fix or add bug2.", new DateTime(2022, 12, 9, 12, 31, 1, 356, DateTimeKind.Local).AddTicks(8132) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
