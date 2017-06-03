namespace SNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserIdToLabelTabel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Labels", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Labels", "UserId");
        }
    }
}
