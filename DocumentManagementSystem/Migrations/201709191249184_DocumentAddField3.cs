namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "MinutesToRead", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "MinutesToRead");
        }
    }
}
