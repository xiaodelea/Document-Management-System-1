namespace DocumentManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentAddField2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Documents", "DocumentTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Documents", "DocumentTime");
        }
    }
}
