namespace SNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToManyRelationshipNoteLabels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Labels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.NoteLabels",
                c => new
                    {
                        NoteId = c.Long(nullable: false),
                        LabelId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.NoteId, t.LabelId })
                .ForeignKey("dbo.Notes", t => t.NoteId, cascadeDelete: true)
                .ForeignKey("dbo.Labels", t => t.LabelId, cascadeDelete: true)
                .Index(t => t.NoteId)
                .Index(t => t.LabelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoteLabels", "LabelId", "dbo.Labels");
            DropForeignKey("dbo.NoteLabels", "NoteId", "dbo.Notes");
            DropIndex("dbo.NoteLabels", new[] { "LabelId" });
            DropIndex("dbo.NoteLabels", new[] { "NoteId" });
            DropTable("dbo.NoteLabels");
            DropTable("dbo.Labels");
        }
    }
}
