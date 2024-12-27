using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IRS.Migrations
{
    /// <inheritdoc />
    public partial class RootMigrationToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cooks_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Deliverers",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Deliverers_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Hosts_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Waiters",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OnWork = table.Column<bool>(type: "bit", nullable: false),
                    ManagerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waiters", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Waiters_Managers_ManagerID",
                        column: x => x.ManagerID,
                        principalTable: "Managers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ToGoOrders",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverPhoneNumber = table.Column<int>(type: "int", nullable: false),
                    DelivererID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HostID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToGoOrders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ToGoOrders_Deliverers_DelivererID",
                        column: x => x.DelivererID,
                        principalTable: "Deliverers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ToGoOrders_Hosts_HostID",
                        column: x => x.HostID,
                        principalTable: "Hosts",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    WaiterID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TableID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Orders_Waiters_WaiterID",
                        column: x => x.WaiterID,
                        principalTable: "Waiters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookToGoOrder",
                columns: table => new
                {
                    CooksID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ToGoOrdersID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookToGoOrder", x => new { x.CooksID, x.ToGoOrdersID });
                    table.ForeignKey(
                        name: "FK_CookToGoOrder_Cooks_CooksID",
                        column: x => x.CooksID,
                        principalTable: "Cooks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookToGoOrder_ToGoOrders_ToGoOrdersID",
                        column: x => x.ToGoOrdersID,
                        principalTable: "ToGoOrders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CookOrder",
                columns: table => new
                {
                    CooksID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    OrdersID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookOrder", x => new { x.CooksID, x.OrdersID });
                    table.ForeignKey(
                        name: "FK_CookOrder_Cooks_CooksID",
                        column: x => x.CooksID,
                        principalTable: "Cooks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CookOrder_Orders_OrdersID",
                        column: x => x.OrdersID,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Availability = table.Column<int>(type: "int", nullable: false),
                    OrderID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ToGoOrderID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Products_ToGoOrders_ToGoOrderID",
                        column: x => x.ToGoOrderID,
                        principalTable: "ToGoOrders",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Tables",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HostID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WaiterID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tables", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tables_Hosts_HostID",
                        column: x => x.HostID,
                        principalTable: "Hosts",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Tables_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tables_Waiters_WaiterID",
                        column: x => x.WaiterID,
                        principalTable: "Waiters",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StorageItems",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    ProductID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageItems", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StorageItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CookOrder_OrdersID",
                table: "CookOrder",
                column: "OrdersID");

            migrationBuilder.CreateIndex(
                name: "IX_Cooks_ManagerID",
                table: "Cooks",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_CookToGoOrder_ToGoOrdersID",
                table: "CookToGoOrder",
                column: "ToGoOrdersID");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverers_ManagerID",
                table: "Deliverers",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_ManagerID",
                table: "Hosts",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_WaiterID",
                table: "Orders",
                column: "WaiterID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_OrderID",
                table: "Products",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ToGoOrderID",
                table: "Products",
                column: "ToGoOrderID");

            migrationBuilder.CreateIndex(
                name: "IX_StorageItems_ProductID",
                table: "StorageItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_HostID",
                table: "Tables",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_OrderId",
                table: "Tables",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Tables_WaiterID",
                table: "Tables",
                column: "WaiterID");

            migrationBuilder.CreateIndex(
                name: "IX_ToGoOrders_DelivererID",
                table: "ToGoOrders",
                column: "DelivererID");

            migrationBuilder.CreateIndex(
                name: "IX_ToGoOrders_HostID",
                table: "ToGoOrders",
                column: "HostID");

            migrationBuilder.CreateIndex(
                name: "IX_Waiters_ManagerID",
                table: "Waiters",
                column: "ManagerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CookOrder");

            migrationBuilder.DropTable(
                name: "CookToGoOrder");

            migrationBuilder.DropTable(
                name: "StorageItems");

            migrationBuilder.DropTable(
                name: "Tables");

            migrationBuilder.DropTable(
                name: "Cooks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ToGoOrders");

            migrationBuilder.DropTable(
                name: "Waiters");

            migrationBuilder.DropTable(
                name: "Deliverers");

            migrationBuilder.DropTable(
                name: "Hosts");

            migrationBuilder.DropTable(
                name: "Managers");
        }
    }
}
