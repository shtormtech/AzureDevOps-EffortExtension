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
                    Inserted = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 30, 21, 7, 36, 353, DateTimeKind.Local).AddTicks(1777)),
                    LastUpdated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2019, 6, 30, 21, 7, 36, 343, DateTimeKind.Local).AddTicks(965))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_timesheet", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "activity_type",
                columns: new[] { "Id", "Code", "Comment", "Deleted", "Name" },
                values: new object[,]
                {
                    { 1L, "analyze", "Анализ задачи", false, "Анализ" },
                    { 2L, "develop", "Разработка", false, "Разработка" },
                    { 3L, "test", "Тестирование", false, "Тестирование" }
                });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 1L, 1L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(6490), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 2L, 1L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8226), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 3L, 1L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8240), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 4L, 2L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8243), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 5L, 2L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8245), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 6L, 2L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8247), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 7L, 2L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8248), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 8L, 3L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8251), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 9L, 3L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8253), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 10L, 3L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8255), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 11L, 3L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8256), false, 15L, "iloer", 1L });

            migrationBuilder.InsertData(
                schema: "effort",
                table: "timesheet",
                columns: new[] { "Id", "ActivityTypeId", "Comment", "Date", "Deleted", "Duration", "UserId", "WorkItemId" },
                values: new object[] { 12L, 3L, "текст", new DateTime(2019, 6, 30, 21, 7, 36, 355, DateTimeKind.Local).AddTicks(8258), false, 15L, "iloer", 1L });
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
