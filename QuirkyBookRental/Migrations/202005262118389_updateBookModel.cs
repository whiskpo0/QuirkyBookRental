namespace QuirkyBookRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Books", "Prive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Prive", c => c.Double(nullable: false));
            DropColumn("dbo.Books", "Price");
        }
    }
}
