using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API6sunday.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "depts",
                columns: table => new
                {
                    DId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_depts", x => x.DId);
                });

            migrationBuilder.CreateTable(
                name: "emps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "both",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    Did = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_both", x => new { x.id, x.Did });
                    table.ForeignKey(
                        name: "FK_both_depts_Did",
                        column: x => x.Did,
                        principalTable: "depts",
                        principalColumn: "DId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_both_emps_id",
                        column: x => x.id,
                        principalTable: "emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "depts",
                columns: new[] { "DId", "Description", "Dname" },
                values: new object[,]
                {
                    { 1, "very good place", "hyderabad" },
                    { 2, "very nice plklac e", "bangalore" }
                });

            migrationBuilder.InsertData(
                table: "emps",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "adnijkadn", "yahswuaj" },
                    { 2, "bhasjdad", "baubhjd" }
                });

            migrationBuilder.InsertData(
                table: "both",
                columns: new[] { "Did", "id" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_both_Did",
                table: "both",
                column: "Did");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "both");

            migrationBuilder.DropTable(
                name: "depts");

            migrationBuilder.DropTable(
                name: "emps");
        }
    }
}
