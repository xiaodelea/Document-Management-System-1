namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "IsBook", c => c.Boolean(nullable: false));
            AddColumn("dbo.Documents", "ISBN", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "ISBN");
            DropColumn("dbo.Documents", "IsBook");
        }
    }
}
