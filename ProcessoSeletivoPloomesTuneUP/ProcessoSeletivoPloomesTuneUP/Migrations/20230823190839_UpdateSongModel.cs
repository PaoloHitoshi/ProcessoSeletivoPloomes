using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcessoSeletivoPloomesTuneUP.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSongModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BandName",
                table: "Songs",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandName",
                table: "Songs");
        }
    }
}
