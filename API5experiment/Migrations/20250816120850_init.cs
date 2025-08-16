using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API5experiment.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.SId);
                });

            migrationBuilder.CreateTable(
                name: "teacher",
                columns: table => new
                {
                    TId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teacher", x => x.TId);
                });

            migrationBuilder.CreateTable(
                name: "enrollment",
                columns: table => new
                {
                    SId = table.Column<int>(type: "int", nullable: false),
                    TId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollment", x => new { x.SId, x.TId });
                    table.ForeignKey(
                        name: "FK_enrollment_student_SId",
                        column: x => x.SId,
                        principalTable: "student",
                        principalColumn: "SId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollment_teacher_TId",
                        column: x => x.TId,
                        principalTable: "teacher",
                        principalColumn: "TId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "SId", "Description", "SName" },
                values: new object[,]
                {
                    { 1, "very good reader", "ganes" },
                    { 2, "very good dancer", "panis" }
                });

            migrationBuilder.InsertData(
                table: "teacher",
                columns: new[] { "TId", "Description", "TName" },
                values: new object[,]
                {
                    { 1, " very good teacher", "yashanth" },
                    { 2, "very bbufb", "baanes" }
                });

            migrationBuilder.InsertData(
                table: "enrollment",
                columns: new[] { "SId", "TId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_enrollment_TId",
                table: "enrollment",
                column: "TId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollment");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "teacher");
        }
    }
}
