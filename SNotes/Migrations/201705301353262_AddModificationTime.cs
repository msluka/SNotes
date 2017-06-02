namespace SNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModificationTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "ModificationTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "ModificationTime");
        }
    }
}
