using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Resumade.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Industries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IndustryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_Industries_IndustryId",
                        column: x => x.IndustryId,
                        principalTable: "Industries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Education",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qualification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserProfileEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Education", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Education_UserProfiles_UserProfileEntityId",
                        column: x => x.UserProfileEntityId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileHobby",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HobbyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileHobby", x => new { x.UserProfileId, x.HobbyId });
                    table.ForeignKey(
                        name: "FK_UserProfileHobby_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileHobby_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileSkills",
                columns: table => new
                {
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileSkills", x => new { x.UserProfileId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_UserProfileSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfileSkills_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EditedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserProfileEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkHistory_UserProfiles_UserProfileEntityId",
                        column: x => x.UserProfileEntityId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("8088aa60-3e4a-447c-9a53-e071fbf8c977"), "Cooking" },
                    { new Guid("bb3cbbe1-bdd0-4505-8f85-1e6b3e5f4dc1"), "Reading" },
                    { new Guid("fda4fcc5-6f6a-42e1-af85-df22b0561b0e"), "Gaming" }
                });

            migrationBuilder.InsertData(
                table: "Industries",
                columns: new[] { "Id", "Name", "Sequence" },
                values: new object[,]
                {
                    { new Guid("099c9d24-9e82-45d4-b458-508ef2898ebf"), "Retail", 12 },
                    { new Guid("0cfe1cbb-d268-4de7-83bb-1a5f1a7a8a19"), "Education", 4 },
                    { new Guid("1372b7fa-8072-4b9f-a6b5-e690885e489f"), "Manufacturing", 8 },
                    { new Guid("16b004b5-d366-4d59-9c1d-0e8d311e4fe4"), "Utilities", 15 },
                    { new Guid("24dae147-9a6c-4a75-a089-e1f675f5495e"), "Whole Sale", 16 },
                    { new Guid("26c2dc07-f129-4b46-b558-ebc043d592a8"), "Construction", 2 },
                    { new Guid("2734eee8-e3f1-48d5-a312-8ac817661be7"), "Logistics", 14 },
                    { new Guid("5084f85a-d2c4-4c78-8a19-9f444f0e3ed4"), "Financial Services", 6 },
                    { new Guid("50d1df04-d557-4d68-bb5a-e4d793cd738c"), "Real Estate", 11 },
                    { new Guid("5a9f4a2d-d8c4-4e5b-ac22-9fa584da91e0"), "Mining", 10 },
                    { new Guid("9113d3a1-ffb3-4957-9827-ca791b7f4ada"), "Administrative", 1 },
                    { new Guid("9369eb14-9ac3-428e-b8f6-80936fb821f0"), "Farming", 5 },
                    { new Guid("b71c53ea-78a5-43bf-b3e7-890db634b30f"), "Technology", 13 },
                    { new Guid("baba9cf6-788e-4ffe-9517-4d079070c1a6"), "Media", 9 },
                    { new Guid("bb604cf6-0bd4-4508-b701-265525101e74"), "Entertainment", 5 },
                    { new Guid("f22e90dd-77b9-420f-8a29-4fc5f361379a"), "Health Care", 7 },
                    { new Guid("f35795bf-eafa-4c63-a481-74ee092dc980"), "Other", 999 },
                    { new Guid("f50fa30a-e868-4dd7-a657-b6c93fdea708"), "Consumer Services", 3 }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("89502f36-e513-4ec6-b9d1-6a9176781d86"), "Problem Solving" },
                    { new Guid("b765dd5f-2e69-4e85-89ec-1456c00c2a4e"), "Communication" },
                    { new Guid("d54427ef-2e57-47c9-be9c-b61750645bc7"), "Teamwork" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "CreatedDate", "EditedDate", "Email", "ImageUrl", "IndustryId", "LastName", "Location", "Name", "Phone", "Summary" },
                values: new object[,]
                {
                    { new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe"), new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9817), new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9818), "john.doe@example.com", "", new Guid("9113d3a1-ffb3-4957-9827-ca791b7f4ada"), "Doe", "Location 1", "John", "123456789", "Profile Summary for John" },
                    { new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648"), new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9883), new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9884), "jane.smith@example.com", "", new Guid("26c2dc07-f129-4b46-b558-ebc043d592a8"), "Smith", "Location 2", "Jane", "987654321", "Profile Summary for Jane" }
                });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "Id", "CreatedDate", "Duration", "EditedDate", "Institution", "Qualification", "UserProfileEntityId" },
                values: new object[,]
                {
                    { new Guid("0b3c9f94-4356-4548-9d42-3247a86583bb"), new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9908), "2 Years", new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9908), "Oxford", "Mechanical Engineering", new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") },
                    { new Guid("23464247-5772-4504-94e8-a3931b0aaa79"), new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9851), "4 Years", new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9857), "MIT", "Computer Science", new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") },
                    { new Guid("561db06f-a659-40ce-ba6d-dfecf9c8a8a1"), new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9906), "3 Years", new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9906), "Stanford", "Computer Engineering", new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") },
                    { new Guid("e62a4961-718c-492b-b9ba-883c888a1b96"), new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9859), "3 Years", new DateTime(2023, 12, 17, 15, 50, 34, 614, DateTimeKind.Local).AddTicks(9859), "Harvard", "Engineering", new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") }
                });

            migrationBuilder.InsertData(
                table: "UserProfileHobby",
                columns: new[] { "HobbyId", "UserProfileId" },
                values: new object[,]
                {
                    { new Guid("bb3cbbe1-bdd0-4505-8f85-1e6b3e5f4dc1"), new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") },
                    { new Guid("fda4fcc5-6f6a-42e1-af85-df22b0561b0e"), new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") },
                    { new Guid("8088aa60-3e4a-447c-9a53-e071fbf8c977"), new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") },
                    { new Guid("fda4fcc5-6f6a-42e1-af85-df22b0561b0e"), new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") }
                });

            migrationBuilder.InsertData(
                table: "UserProfileSkills",
                columns: new[] { "SkillId", "UserProfileId" },
                values: new object[,]
                {
                    { new Guid("b765dd5f-2e69-4e85-89ec-1456c00c2a4e"), new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") },
                    { new Guid("d54427ef-2e57-47c9-be9c-b61750645bc7"), new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") },
                    { new Guid("89502f36-e513-4ec6-b9d1-6a9176781d86"), new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") },
                    { new Guid("b765dd5f-2e69-4e85-89ec-1456c00c2a4e"), new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") }
                });

            migrationBuilder.InsertData(
                table: "WorkHistory",
                columns: new[] { "Id", "Company", "CreatedDate", "Description", "Duration", "EditedDate", "Position", "UserProfileEntityId" },
                values: new object[,]
                {
                    { new Guid("30db1286-ea8a-4a4e-a670-2cba0161bdf7"), "Company B", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9873), "Managed several teams", "4 Years", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9873), "Project Manager", new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") },
                    { new Guid("4989bcae-2905-4428-b45f-9f364e785f78"), "Company C", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9918), "Worked in machine learning projects", "3 Years", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9918), "Data Scientist", new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") },
                    { new Guid("6e2e2d85-63e6-45b4-a325-113ad622a08a"), "Company A", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9871), "Worked on various projects", "2 Years", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9871), "Software Engineer", new Guid("c7d7a373-91eb-4f3c-b271-2a0cd4c00cfe") },
                    { new Guid("d1854d24-ee6b-4a39-8850-5b2e4e0bba1c"), "Company D", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9920), "Developed and launched new products", "5 Years", new DateTime(2023, 12, 17, 13, 50, 34, 614, DateTimeKind.Utc).AddTicks(9920), "Product Manager", new Guid("f330da02-4d80-4e8f-b51a-b2984f9dd648") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserProfileEntityId",
                table: "Education",
                column: "UserProfileEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileHobby_HobbyId",
                table: "UserProfileHobby",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IndustryId",
                table: "UserProfiles",
                column: "IndustryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfileSkills_SkillId",
                table: "UserProfileSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkHistory_UserProfileEntityId",
                table: "WorkHistory",
                column: "UserProfileEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Education");

            migrationBuilder.DropTable(
                name: "UserProfileHobby");

            migrationBuilder.DropTable(
                name: "UserProfileSkills");

            migrationBuilder.DropTable(
                name: "WorkHistory");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "Industries");
        }
    }
}
