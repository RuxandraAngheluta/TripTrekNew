using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TripTrek.Migrations
{
    /// <inheritdoc />
    public partial class NewMig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "Password",
               table: "Accounts",
               type: "nvarchar(256)",
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(50)",
               oldNullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "Password",
               table: "Accounts",
               type: "nvarchar(50)",
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(256)",
               oldNullable: false);
        }
    }
}
