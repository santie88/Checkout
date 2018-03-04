namespace Checkout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateDatabase : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Items (Name, Price) VALUES ('Notebook', 1000)");
            Sql("INSERT INTO Items (Name, Price) VALUES ('Monitor', 200)");
            Sql("INSERT INTO Items (Name, Price) VALUES ('Speakers', 300)");
            Sql("INSERT INTO Items (Name, Price) VALUES ('Tablet', 250)");

            Sql("INSERT INTO Customers (Name) VALUES ('John Smith')");
            Sql("INSERT INTO Customers (Name) VALUES ('Max Hint')");
            Sql("INSERT INTO Customers (Name) VALUES ('Robert Wood')");
        }
        
        public override void Down()
        {
        }
    }
}
