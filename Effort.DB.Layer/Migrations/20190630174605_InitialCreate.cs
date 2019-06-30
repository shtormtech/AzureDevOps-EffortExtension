using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Effort.DB.Layer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "effort");

            migrationBuilder.CreateTable(
                name: "activity_type",
                schema: "effort",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_activity_type", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "timesheet",
                schema: "effort",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    ActivityTypeId = table.Column<long>(nullable: false),
                    UserId = table.Column<string>(maxLength: 250, nullable: false),
                    WorkItemId = table.Column<long>(nullable: false),
                    Duration = table.Column<long>(nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheet", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "activity_type",
                columns: new[] { "Id", "Comment", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1L, "Анализ задачи", false, "Анализ" },
                    { 2L, "Разработка", false, "Разработка" },
                    { 3L, "Тестирование", false, "Тестирование" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "activity_type",
                schema: "effort");

            migrationBuilder.DropTable(
                name: "timesheet",
                schema: "effort");
        }
    }
}
