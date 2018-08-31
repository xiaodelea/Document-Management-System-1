namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionCategories",
                c => new
                    {
                        AdditionCategoryId = c.Guid(nullable: false),
                        Name = c.String(),
                        IsUseForBook = c.Boolean(nullable: false),
                        UpdateTime = c.DateTime(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.AdditionCategoryId);
            
            CreateTable(
                "dbo.Additions",
                c => new
                    {
                        AdditionId = c.Guid(nullable: false),
                        AdditionCategoryId = c.Guid(nullable: false),
                        DocumentId = c.Guid(nullable: false),
                        Description = c.String(),
                        UpdateTime = c.DateTime(nullable: false),
                        TimeStamp = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.AdditionId)
                .ForeignKey("dbo.AdditionCategories", t => t.AdditionCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Documents", t => t.DocumentId, cascadeDelete: true)
                .Index(t => t.AdditionCategoryId)
                .Index(t => t.DocumentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Additions", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Additions", "AdditionCategoryId", "dbo.AdditionCategories");
            DropIndex("dbo.Additions", new[] { "DocumentId" });
            DropIndex("dbo.Additions", new[] { "AdditionCategoryId" });
            DropTable("dbo.Additions");
            DropTable("dbo.AdditionCategories");
        }
    }
}
