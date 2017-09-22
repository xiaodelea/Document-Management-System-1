namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "IsBookmarked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "IsBookmarked");
        }
    }
}
