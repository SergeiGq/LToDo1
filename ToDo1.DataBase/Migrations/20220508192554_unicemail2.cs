using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDo1.DataBase.Migrations
{
    public partial class unicemail2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ToDoRegistrs_Email",
                table: "ToDoRegistrs",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDoRegistrs_Email",
                table: "ToDoRegistrs");
        }
    }
}
