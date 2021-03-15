using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentSystem.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 25, nullable: true),
                    LastName = table.Column<string>(maxLength: 25, nullable: true),
                    Address = table.Column<string>(maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SenderCardId = table.Column<Guid>(nullable: false),
                    RecipientCardId = table.Column<Guid>(nullable: false),
                    AmountOfMoney = table.Column<double>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientId = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    AmountOfMoney = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccounts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ClientName = table.Column<string>(maxLength: 50, nullable: false),
                    BankAccountId = table.Column<Guid>(nullable: false),
                    CardNumber = table.Column<string>(maxLength: 16, nullable: false),
                    IssueDate = table.Column<DateTime>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    Cvc = table.Column<int>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_BankAccounts_BankAccountId",
                        column: x => x.BankAccountId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Address", "DateCreated", "DateOfBirth", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("ef74f0f4-fcca-4751-a39e-4faae75f9123"), "New York, Green Streen 13", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thor", "Odinson", "32568978568" },
                    { new Guid("16db1414-387c-40d1-89e3-05945c4661a1"), "New York, Yellow Streen 11", new DateTime(2021, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tony", "Stark", "36589875659" },
                    { new Guid("c5a3b5dc-caa1-4b00-987b-b3acf0527397"), "New York, Brown Streen 10", new DateTime(2021, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bruce", "Banner", "34587965865" },
                    { new Guid("28e1de8a-715a-4d50-8a08-2d86caca0bb4"), "New York, Red Streen 15", new DateTime(2021, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 4, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wanda", "Maximoff", "32532547896" },
                    { new Guid("d7fafcdd-faf2-472d-9d52-4c9256c77149"), "New York, Black Streen 14", new DateTime(2021, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1977, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victor", "Shade", "32987563545" },
                    { new Guid("1d8f8003-fd0e-42b5-9f7e-05b766de6340"), "New York, White Streen 12", new DateTime(2021, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dane", "Whitman", "36548998566" }
                });

            migrationBuilder.InsertData(
                table: "BankAccounts",
                columns: new[] { "Id", "AmountOfMoney", "ClientId", "DateCreated" },
                values: new object[,]
                {
                    { new Guid("87ab530a-aa4a-4fcb-a09d-436c03be080c"), 10000.0, new Guid("ef74f0f4-fcca-4751-a39e-4faae75f9123"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a41713c6-393e-4202-b490-62028bac8aed"), 20000.0, new Guid("16db1414-387c-40d1-89e3-05945c4661a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("56617f02-32fd-4c1a-83ce-341e7af16a25"), 20000.0, new Guid("c5a3b5dc-caa1-4b00-987b-b3acf0527397"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b5385b9-5157-4d4c-a883-1ea0c2bff1ed"), 30000.0, new Guid("28e1de8a-715a-4d50-8a08-2d86caca0bb4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("54bf5559-3ded-4338-98f5-02d18509e7fd"), 40000.0, new Guid("d7fafcdd-faf2-472d-9d52-4c9256c77149"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("52ef23aa-621f-4184-b88b-263f5f2e4b0f"), 50000.0, new Guid("d7fafcdd-faf2-472d-9d52-4c9256c77149"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2f524819-7b82-404f-b55b-af16d5fcf98e"), 60000.0, new Guid("1d8f8003-fd0e-42b5-9f7e-05b766de6340"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "BankAccountId", "CardNumber", "ClientName", "Cvc", "ExpirationDate", "IssueDate" },
                values: new object[,]
                {
                    { new Guid("6c24145b-2b66-40b9-8057-a1c6c80e114f"), new Guid("87ab530a-aa4a-4fcb-a09d-436c03be080c"), "1234789565897412", "Thor Odinson", 123, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c85e2b5d-e144-4076-af2d-9281ec0c6e98"), new Guid("a41713c6-393e-4202-b490-62028bac8aed"), "5847632589562417", "Tony Stark", 734, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("19916e12-94c2-48bf-baa8-daabc5d43264"), new Guid("a41713c6-393e-4202-b490-62028bac8aed"), "2569875896325698", "Tony Stark", 745, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9adbaebc-78e5-4cca-be0d-f05871f1a476"), new Guid("56617f02-32fd-4c1a-83ce-341e7af16a25"), "3256874596325874", "Bruce Banner", 846, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("80b10d23-b9d4-415b-b247-2290c6752b93"), new Guid("56617f02-32fd-4c1a-83ce-341e7af16a25"), "8745102356985478", "Bruce Banner", 137, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5fabe04-1620-4750-8601-df9c0d7dd2e3"), new Guid("5b5385b9-5157-4d4c-a883-1ea0c2bff1ed"), "1023547895235687", "Wanda Maximoff", 128, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("42bd14da-8ebb-4344-9f07-8cd6bdb63675"), new Guid("54bf5559-3ded-4338-98f5-02d18509e7fd"), "2014258785693258", "Victor Shade", 129, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eddb3ea9-6306-4225-9f9a-520028104d71"), new Guid("52ef23aa-621f-4184-b88b-263f5f2e4b0f"), "5024785695874253", "Victor Shade", 120, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a486232-f9c5-4805-9858-862e4956f0d9"), new Guid("2f524819-7b82-404f-b55b-af16d5fcf98e"), "3256985620147452", "Dane Whitman", 112, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd7f6807-04de-4190-81b4-914331a22cef"), new Guid("2f524819-7b82-404f-b55b-af16d5fcf98e"), "3025485695874123", "Dane Whitman", 132, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_ClientId",
                table: "BankAccounts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_BankAccountId",
                table: "Cards",
                column: "BankAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
