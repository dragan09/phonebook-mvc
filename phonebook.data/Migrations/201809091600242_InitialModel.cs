namespace phonebook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        Surname = c.String(maxLength: 15),
                        Nickname = c.String(nullable: false, maxLength: 8),
                        MobilePhone = c.String(nullable: false, maxLength: 13),
                        Group_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group", t => t.Group_ID)
                .Index(t => t.Group_ID);
            
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contact", "Group_ID", "dbo.Group");
            DropIndex("dbo.Contact", new[] { "Group_ID" });
            DropTable("dbo.Group");
            DropTable("dbo.Contact");
        }
    }
}
