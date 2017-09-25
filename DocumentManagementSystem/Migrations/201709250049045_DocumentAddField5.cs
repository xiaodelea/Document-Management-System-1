namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "IsGetAllChapters", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "IsGetAllChapters");
        }
    }
}
