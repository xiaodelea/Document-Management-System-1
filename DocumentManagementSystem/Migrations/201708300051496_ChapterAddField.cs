namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChapterAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Chapters", "UpdateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Chapters", "TimeStamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Chapters", "TimeStamp");
            DropColumn("dbo.Chapters", "UpdateTime");
        }
    }
}
