namespace Checkout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelDB1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Item_Id" });
            DropIndex("dbo.OrderItems", new[] { "Order_Id" });
            RenameColumn(table: "dbo.OrderItems", name: "Item_Id", newName: "ItemId");
            RenameColumn(table: "dbo.OrderItems", name: "Order_Id", newName: "OrderId");
            AlterColumn("dbo.OrderItems", "ItemId", c => c.Int(nullable: false));
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderItems", "OrderId");
            CreateIndex("dbo.OrderItems", "ItemId");
            AddForeignKey("dbo.OrderItems", "ItemId", "dbo.Items", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "ItemId", "dbo.Items");
            DropIndex("dbo.OrderItems", new[] { "ItemId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            AlterColumn("dbo.OrderItems", "OrderId", c => c.Int());
            AlterColumn("dbo.OrderItems", "ItemId", c => c.Int());
            RenameColumn(table: "dbo.OrderItems", name: "OrderId", newName: "Order_Id");
            RenameColumn(table: "dbo.OrderItems", name: "ItemId", newName: "Item_Id");
            CreateIndex("dbo.OrderItems", "Order_Id");
            CreateIndex("dbo.OrderItems", "Item_Id");
            AddForeignKey("dbo.OrderItems", "Order_Id", "dbo.Orders", "Id");
            AddForeignKey("dbo.OrderItems", "Item_Id", "dbo.Items", "Id");
        }
    }
}
