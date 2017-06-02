namespace SNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropLabelTabel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NoteLabels", "Label_Id", "dbo.Labels");
            DropForeignKey("dbo.NoteLabels", "Note_Id", "dbo.Notes");
            DropIndex("dbo.NoteLabels", new[] { "Label_Id" });
            DropIndex("dbo.NoteLabels", new[] { "Note_Id" });
            DropTable("dbo.NoteLabels");
        }
        
        public override void Down()
        {
            
        }
    }
}
