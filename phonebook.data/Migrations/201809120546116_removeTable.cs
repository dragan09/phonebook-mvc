namespace phonebook.data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Contact", "Group_ID", "dbo.Group");
            DropIndex("dbo.Contact", new[] { "Group_ID" });
            AddColumn("dbo.Contact", "GroupName", c => c.String(maxLength: 10));
            DropColumn("dbo.Contact", "Group_ID");
            DropTable("dbo.Group");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Contact", "Group_ID", c => c.Long());
            DropColumn("dbo.Contact", "GroupName");
            CreateIndex("dbo.Contact", "Group_ID");
            AddForeignKey("dbo.Contact", "Group_ID", "dbo.Group", "ID");
        }
    }
}
