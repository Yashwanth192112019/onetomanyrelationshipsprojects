using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace newAPI2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpeciesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Habitat = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_animals", x => x.AnimalId);
                });

            migrationBuilder.CreateTable(
                name: "birds",
                columns: table => new
                {
                    BirdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirdName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_birds", x => x.BirdId);
                    table.ForeignKey(
                        name: "FK_birds_animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "animals",
                columns: new[] { "AnimalId", "Description", "Habitat", "SpeciesName" },
                values: new object[,]
                {
                    { 1, "flies high and became bald", "mountains", "bald eagle" },
                    { 2, "walks high and became bald", "North pole", "bald penguin" },
                    { 3, "bites but became bald", "forest", "bald tiger" },
                    { 4, "slept  and became bald", "mountains", "bald lion" },
                    { 5, "ate high and became bald", "mountains", "bald buffalo" }
                });

            migrationBuilder.InsertData(
                table: "birds",
                columns: new[] { "BirdId", "Age", "AnimalId", "BirdName", "Color" },
                values: new object[,]
                {
                    { 1, 22, 2, "barad", "black and white" },
                    { 2, 25, 1, "bread", "blue and green" },
                    { 3, 31, 4, "sbarrow", "skin calar" },
                    { 4, 45, 3, "barrot", "blue" },
                    { 5, 50, 1, "baloon", "green and red" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_birds_AnimalId",
                table: "birds",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "birds");

            migrationBuilder.DropTable(
                name: "animals");
        }
    }
}
