using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace relmanytomany.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "birds",
                columns: table => new
                {
                    bId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birds", x => x.bId);
                });

            migrationBuilder.CreateTable(
                name: "cantflybirds",
                columns: table => new
                {
                    cId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cantflybirds", x => x.cId);
                });

            migrationBuilder.CreateTable(
                name: "both",
                columns: table => new
                {
                    bid = table.Column<int>(type: "int", nullable: false),
                    cId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_both", x => new { x.bid, x.cId });
                    table.ForeignKey(
                        name: "FK_both_birds_bid",
                        column: x => x.bid,
                        principalTable: "birds",
                        principalColumn: "bId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_both_cantflybirds_cId",
                        column: x => x.cId,
                        principalTable: "cantflybirds",
                        principalColumn: "cId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "birds",
                columns: new[] { "bId", "age", "cname" },
                values: new object[,]
                {
                    { 1, 4, "yashwanth" },
                    { 2, 8, "jnadk" }
                });

            migrationBuilder.InsertData(
                table: "cantflybirds",
                columns: new[] { "cId", "age", "bname" },
                values: new object[,]
                {
                    { 1, 22, "b SJK" },
                    { 2, 34, "yashoo" }
                });

            migrationBuilder.InsertData(
                table: "both",
                columns: new[] { "bid", "cId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_both_cId",
                table: "both",
                column: "cId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "both");

            migrationBuilder.DropTable(
                name: "birds");

            migrationBuilder.DropTable(
                name: "cantflybirds");
        }
    }
}
