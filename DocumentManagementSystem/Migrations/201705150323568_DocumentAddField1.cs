namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "Remarks");
        }
    }
}
