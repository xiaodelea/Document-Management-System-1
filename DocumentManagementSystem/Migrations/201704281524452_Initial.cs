namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Guid(nullable: false),
                        ParentDocumentId = c.Guid(),
                        Title = c.String(nullable: false),
                        NodeName = c.String(nullable: false),
                        Priority = c.Int(),
                        UpdateTimeForHTTPGet = c.DateTime(nullable: false),
                        IsChecked = c.Boolean(nullable: false),
                        IsNoted = c.Boolean(nullable: false),
                        IsGetAllChildren = c.Boolean(nullable: false),
                        SourceTextMainContain = c.String(),
                        SourceTextMainContainBackup = c.String(),
                        SourceTextHashCode = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Documents", t => t.ParentDocumentId)
                .Index(t => t.ParentDocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "ParentDocumentId", "dbo.Documents");
            DropIndex("dbo.Documents", new[] { "ParentDocumentId" });
            DropTable("dbo.Documents");
        }
    }
}
