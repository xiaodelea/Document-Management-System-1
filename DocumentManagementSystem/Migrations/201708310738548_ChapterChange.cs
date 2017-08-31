namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChapterChange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Chapters", "ChapterName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Chapters", "ChapterName", c => c.String());
        }
    }
}
