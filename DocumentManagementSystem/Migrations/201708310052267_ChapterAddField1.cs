namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChapterAddField1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapters", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapters", "Priority");
        }
    }
}
