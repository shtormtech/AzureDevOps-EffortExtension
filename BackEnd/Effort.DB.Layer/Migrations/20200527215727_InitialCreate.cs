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
                    Code = table.Column<string>(maxLength: 100, nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(maxLength: 30, nullable: false)
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
                    WorkItemId = table.Column<int>(nullable: false),
                    Duration = table.Column<long>(nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Inserted = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 28, 0, 57, 26, 43, DateTimeKind.Local).AddTicks(1148)),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 5, 28, 0, 57, 26, 29, DateTimeKind.Local).AddTicks(6163))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheet", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "activity_type",
                columns: new[] { "Id", "Code", "Color", "Comment", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1L, "analyze", "red", "Анализ задачи", false, "Анализ" },
                    { 2L, "develop", "green", "Разработка", false, "Разработка" },
                    { 3L, "test", "blue", "Тестирование", false, "Тестирование" }
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 1L, 1L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(4013), true, 15L, "iloer", 11 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 2L, 1L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7003), false, 15L, "iloer", 22 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 3L, 1L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7021), false, 15L, "iloer", 33 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 4L, 2L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7125), true, 15L, "iloer", 44 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 5L, 2L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7133), false, 15L, "iloer", 55 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 6L, 2L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7134), false, 15L, "iloer", 66 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 7L, 2L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7136), false, 15L, "iloer", 77 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 8L, 3L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7137), true, 15L, "iloer", 88 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 9L, 3L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7138), false, 15L, "iloer", 99 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 10L, 3L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7140), false, 15L, "iloer", 100 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 11L, 3L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7141), false, 15L, "iloer", 110 });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 12L, 3L, "текст", new DateTime(2020, 5, 28, 0, 57, 26, 46, DateTimeKind.Local).AddTicks(7143), false, 15L, "iloer", 120 });
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
