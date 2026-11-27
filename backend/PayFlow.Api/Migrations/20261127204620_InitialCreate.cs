using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PayFlow.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Reference = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    PayerName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", precision: 18, scale: 2, nullable: false),
                    Currency = table.Column<string>(type: "TEXT", maxLength: 3, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Status = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "Amount", "CreatedAt", "Currency", "Description", "PayerName", "Reference", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), 149.99m, new DateTime(2026, 11, 1, 9, 0, 0, 0, DateTimeKind.Utc), "EUR", "Invoice 1001", "Anna Schmidt", "PAY-20261101-SEED01", "Completed", new DateTime(2026, 11, 1, 9, 5, 0, 0, DateTimeKind.Utc) },
                    { new Guid("22222222-2222-2222-2222-222222222222"), 89.50m, new DateTime(2026, 11, 2, 14, 30, 0, 0, DateTimeKind.Utc), "EUR", "Subscription November", "Max Müller", "PAY-20261102-SEED02", "Pending", null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), 1200.00m, new DateTime(2026, 11, 3, 11, 15, 0, 0, DateTimeKind.Utc), "EUR", "Laptop order", "Lena Weber", "PAY-20261103-SEED03", "Failed", new DateTime(2026, 11, 3, 11, 16, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Reference",
                table: "Payments",
                column: "Reference",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
