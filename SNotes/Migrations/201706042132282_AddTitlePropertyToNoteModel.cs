namespace SNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTitlePropertyToNoteModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "Title");
        }
    }
}
