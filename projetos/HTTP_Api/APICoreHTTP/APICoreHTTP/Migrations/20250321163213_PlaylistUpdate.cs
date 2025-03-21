using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICoreHTTP.Migrations
{
    /// <inheritdoc />
    public partial class PlaylistUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlaylistId",
                table: "Musics",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Musics_PlaylistId",
                table: "Musics",
                column: "PlaylistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Musics_Playlists_PlaylistId",
                table: "Musics",
                column: "PlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musics_Playlists_PlaylistId",
                table: "Musics");

            migrationBuilder.DropIndex(
                name: "IX_Musics_PlaylistId",
                table: "Musics");

            migrationBuilder.DropColumn(
                name: "PlaylistId",
                table: "Musics");
        }
    }
}
