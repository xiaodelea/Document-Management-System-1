namespace DocumentManagementSystem.Migrations.Domains.MySQL
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionCategories",
                c => new
                    {
                        AdditionCategoryId = c.Guid(nullable: false),
                        Name = c.String(unicode: false),
                        IsUseForBook = c.Boolean(nullable: false),
                        UpdateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.AdditionCategoryId);
            
            CreateTable(
                "dbo.Additions",
                c => new
                    {
                        AdditionId = c.Guid(nullable: false),
                        AdditionCategoryId = c.Guid(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        Description = c.String(unicode: false),
                        UpdateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.AdditionId)
                .ForeignKey("dbo.AdditionCategories", t => t.AdditionCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.AdditionCategoryId)
                .Index(t => t.DocumentId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        DocumentId = c.Guid(nullable: false),
                        ParentDocumentId = c.Guid(),
                        Title = c.String(nullable: false, unicode: false),
                        NodeName = c.String(nullable: false, unicode: false),
                        Priority = c.Int(),
                        UpdateTimeForHTTPGet = c.DateTime(nullable: false, precision: 0),
                        IsChecked = c.Boolean(nullable: false),
                        IsNoted = c.Boolean(nullable: false),
                        IsGetAllChildren = c.Boolean(nullable: false),
                        IsGetAllChapters = c.Boolean(nullable: false),
                        DocumentTime = c.DateTime(precision: 0),
                        Url = c.String(unicode: false),
                        SourceTextMainContain = c.String(unicode: false),
                        SourceTextMainContainBackup = c.String(unicode: false),
                        SourceTextHashCode = c.String(unicode: false),
                        Remarks = c.String(unicode: false),
                        MinutesToRead = c.Int(),
                        IsBookmarked = c.Boolean(nullable: false),
                        IsBook = c.Boolean(nullable: false),
                        ISBN = c.String(unicode: false),
                        IsAbstract = c.Boolean(nullable: false),
                        IsMain = c.Boolean(nullable: false),
                        UpdateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.DocumentId)
                .ForeignKey("dbo.Documents", t => t.ParentDocumentId)
                .Index(t => t.ParentDocumentId);
            
            CreateTable(
                "dbo.Chapters",
                c => new
                    {
                        ChapterId = c.Guid(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        ChapterName = c.String(nullable: false, unicode: false),
                        Priority = c.Int(nullable: false),
                        UpdateTime = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.ChapterId)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Additions", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "ParentDocumentId", "dbo.Documents");
            DropForeignKey("dbo.Chapters", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Additions", "AdditionCategoryId", "dbo.AdditionCategories");
            DropIndex("dbo.Chapters", new[] { "DocumentId" });
            DropIndex("dbo.Documents", new[] { "ParentDocumentId" });
            DropIndex("dbo.Additions", new[] { "DocumentId" });
            DropIndex("dbo.Additions", new[] { "AdditionCategoryId" });
            DropTable("dbo.Chapters");
            DropTable("dbo.Documents");
            DropTable("dbo.Additions");
            DropTable("dbo.AdditionCategories");
        }
    }
}
