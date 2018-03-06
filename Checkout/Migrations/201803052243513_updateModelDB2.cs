namespace Checkout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateModelDB2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Number", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
