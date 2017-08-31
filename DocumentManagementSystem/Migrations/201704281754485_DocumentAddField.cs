namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "Url");
        }
    }
}
