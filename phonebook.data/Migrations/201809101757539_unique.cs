namespace phonebook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class unique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contact", "Nickname", unique: true);
            CreateIndex("dbo.Contact", "MobilePhone", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Contact", new[] { "MobilePhone" });
            DropIndex("dbo.Contact", new[] { "Nickname" });
        }
    }
}
