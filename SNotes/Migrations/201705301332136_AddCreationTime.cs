namespace SNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "CreationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "CreationTime");
        }
    }
}
