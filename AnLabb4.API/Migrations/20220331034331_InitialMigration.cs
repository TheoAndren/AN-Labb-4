using Microsoft.EntityFrameworkCore.Migrations;

namespace AnLabb4.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    InterestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestTitle = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.InterestId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.PersonId);
                });

            migrationBuilder.CreateTable(
                name: "Websites",
                columns: table => new
                {
                    WebsiteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Websites", x => x.WebsiteId);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterestLinks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: true),
                    InterestId = table.Column<int>(nullable: true),
                    WebsiteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterestLinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInterestLinks_Interests_InterestId",
                        column: x => x.InterestId,
                        principalTable: "Interests",
                        principalColumn: "InterestId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonInterestLinks_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PersonInterestLinks_Websites_WebsiteId",
                        column: x => x.WebsiteId,
                        principalTable: "Websites",
                        principalColumn: "WebsiteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "InterestId", "Description", "InterestTitle" },
                values: new object[,]
                {
                    { 1, "Hockey is a team based sport played 5v5 + a goalie", "Hockey" },
                    { 2, "Floorball is a team based sport played 5v5 + a goalie", "Floorball" },
                    { 3, "League of legends is a team based strategy computer game played 5v5", "LeagueOfLegends" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "PersonId", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Anas", "Qlok", "072542302" },
                    { 2, "Tobias", "Qlok", "0734242" },
                    { 3, "Reidar", "Qlok", "074241" }
                });

            migrationBuilder.InsertData(
                table: "Websites",
                columns: new[] { "WebsiteId", "Link" },
                values: new object[,]
                {
                    { 1, "https://www.laget.se/KungsbackaHC" },
                    { 2, "https://www.varlaibk.nu/start/?ID=16231" },
                    { 3, "https://www.leagueoflegends.com/en-gb/" }
                });

            migrationBuilder.InsertData(
                table: "PersonInterestLinks",
                columns: new[] { "Id", "InterestId", "PersonId", "WebsiteId" },
                values: new object[] { 2, 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "PersonInterestLinks",
                columns: new[] { "Id", "InterestId", "PersonId", "WebsiteId" },
                values: new object[] { 1, 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "PersonInterestLinks",
                columns: new[] { "Id", "InterestId", "PersonId", "WebsiteId" },
                values: new object[] { 3, 3, 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterestLinks_InterestId",
                table: "PersonInterestLinks",
                column: "InterestId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterestLinks_PersonId",
                table: "PersonInterestLinks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterestLinks_WebsiteId",
                table: "PersonInterestLinks",
                column: "WebsiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonInterestLinks");

            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Websites");
        }
    }
}
