namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelChapter : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        ChapterId = c.Guid(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        ChapterName = c.String(),
                    })
                .PrimaryKey(t => t.ChapterId)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Chapters", "DocumentId", "dbo.Documents");
            DropIndex("dbo.Chapters", new[] { "DocumentId" });
            DropTable("dbo.Chapters");
        }
    }
}
