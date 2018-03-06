namespace Checkout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDBStructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            AddColumn("dbo.Orders", "IdCustomer", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "Customer_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            AlterColumn("dbo.Orders", "Customer_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "IdCustomer");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
