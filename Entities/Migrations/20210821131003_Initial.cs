using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoList_Table",
                columns: table => new
                {
                    ToDoListId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    CreateDate = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoList_Table", x => x.ToDoListId);
                });

            migrationBuilder.CreateTable(
                name: "ToDoItem_Table",
                columns: table => new
                {
                    ToDoItemId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<string>(nullable: false),
                    ToDoListId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoItem_Table", x => x.ToDoItemId);
                    table.ForeignKey(
                        name: "FK_ToDoItem_Table_ToDoList_Table_ToDoListId",
                        column: x => x.ToDoListId,
                        principalTable: "ToDoList_Table",
                        principalColumn: "ToDoListId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ToDoList_Table",
                columns: new[] { "ToDoListId", "CreateDate", "Name" },
                values: new object[] { new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc"), new DateTimeOffset(new DateTime(2021, 8, 21, 13, 10, 2, 619, DateTimeKind.Unspecified).AddTicks(8868), new TimeSpan(0, 0, 0, 0, 0)), "Shopping" });

            migrationBuilder.InsertData(
                table: "ToDoList_Table",
                columns: new[] { "ToDoListId", "CreateDate", "Name" },
                values: new object[] { new Guid("660ed4cd-1361-4216-9faa-9636e4df681a"), new DateTimeOffset(new DateTime(2021, 8, 21, 13, 10, 2, 619, DateTimeKind.Unspecified).AddTicks(9673), new TimeSpan(0, 0, 0, 0, 0)), "Home" });

            migrationBuilder.InsertData(
                table: "ToDoItem_Table",
                columns: new[] { "ToDoItemId", "Description", "Name", "Status", "ToDoListId" },
                values: new object[,]
                {
                    { new Guid("6d275162-39d8-4d74-b912-5de60172b7c6"), "Carrots, Tomatoes", "Vegetals", "PENDING", new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc") },
                    { new Guid("2471077e-8c15-4f30-90e2-b945bb4ca8c7"), "Beaf, Bacon", "Meat", "PENDING", new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc") },
                    { new Guid("da350fe2-00c0-47c8-ac8f-7487426cbf11"), "Budweiser", "Beer", "PENDING", new Guid("410c14e3-e6df-35c8-8c6f-1e19aed675bc") },
                    { new Guid("f599c235-6eee-4734-bf73-e81e53692743"), "Wash Shoes", "Laundry", "PENDING", new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") },
                    { new Guid("af374b3a-7f95-4fda-9f17-eb368dbd2567"), "Raviolis", "Cook", "PENDING", new Guid("660ed4cd-1361-4216-9faa-9636e4df681a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItem_Table_ToDoListId",
                table: "ToDoItem_Table",
                column: "ToDoListId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoItem_Table");

            migrationBuilder.DropTable(
                name: "ToDoList_Table");
        }
    }
}
