using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorTodos.Migrations
{
    /// <inheritdoc />
    public partial class AuditItemCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Todos",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "AuditionTodos",
                columns: table => new
                {
                    AuditionId = table.Column<string>(type: "text", nullable: false),
                    DeletionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TodoItemId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditionTodos", x => x.AuditionId);
                    table.ForeignKey(
                        name: "FK_AuditionTodos_Todos_TodoItemId",
                        column: x => x.TodoItemId,
                        principalTable: "Todos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuditionTodos_TodoItemId",
                table: "AuditionTodos",
                column: "TodoItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditionTodos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Todos");
        }
    }
}
