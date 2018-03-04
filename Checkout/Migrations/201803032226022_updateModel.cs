namespace Checkout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Orders", "Number", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Orders", "Customer_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            AlterColumn("dbo.Orders", "Customer_Id", c => c.Int());
            AlterColumn("dbo.Orders", "Number", c => c.String());
            AlterColumn("dbo.Items", "Name", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
