namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "IsAbstract", c => c.Boolean(nullable: false));
            AddColumn("dbo.Documents", "IsMain", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "IsMain");
            DropColumn("dbo.Documents", "IsAbstract");
        }
    }
}
