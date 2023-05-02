using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training.Sql.Entity.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "blobs",
                schema: "public",
                columns: table => new
                {
                    blob_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "text", nullable: false),
                    file_path = table.Column<string>(type: "text", nullable: false),
                    mime = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("blob_pkey", x => x.blob_id);
                });

            migrationBuilder.CreateTable(
                name: "theatre_types",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_theatre_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cinemas",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    blob_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("cinema_pkey", x => x.id);
                    table.ForeignKey(
                        name: "u__blob_fkey",
                        column: x => x.blob_id,
                        principalSchema: "public",
                        principalTable: "blobs",
                        principalColumn: "blob_id");
                });

            migrationBuilder.CreateTable(
                name: "theatres",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    cinema_id = table.Column<int>(type: "integer", nullable: false),
                    theatre_type_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("theatre_pkey", x => x.id);
                    table.ForeignKey(
                        name: "t__cinema_fkey",
                        column: x => x.cinema_id,
                        principalSchema: "public",
                        principalTable: "cinemas",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "t__theatreType_fkey",
                        column: x => x.theatre_type_id,
                        principalSchema: "public",
                        principalTable: "theatre_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "public",
                table: "theatre_types",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Reguler" },
                    { 2, "Premium" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_cinemas_blob_id",
                schema: "public",
                table: "cinemas",
                column: "blob_id");

            migrationBuilder.CreateIndex(
                name: "ix_theatres_cinema_id",
                schema: "public",
                table: "theatres",
                column: "cinema_id");

            migrationBuilder.CreateIndex(
                name: "ix_theatres_theatre_type_id",
                schema: "public",
                table: "theatres",
                column: "theatre_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "theatres",
                schema: "public");

            migrationBuilder.DropTable(
                name: "cinemas",
                schema: "public");

            migrationBuilder.DropTable(
                name: "theatre_types",
                schema: "public");

            migrationBuilder.DropTable(
                name: "blobs",
                schema: "public");
        }
    }
}
