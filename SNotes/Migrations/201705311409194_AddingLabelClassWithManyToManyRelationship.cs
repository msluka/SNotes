namespace SNotes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLabelClassWithManyToManyRelationship : DbMigration
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
                        Note_Id = c.Long(nullable: false),
                        Label_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Note_Id, t.Label_Id })
                .ForeignKey("dbo.Notes", t => t.Note_Id, cascadeDelete: true)
                .ForeignKey("dbo.Labels", t => t.Label_Id, cascadeDelete: true)
                .Index(t => t.Note_Id)
                .Index(t => t.Label_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NoteLabels", "Label_Id", "dbo.Labels");
            DropForeignKey("dbo.NoteLabels", "Note_Id", "dbo.Notes");
            DropIndex("dbo.NoteLabels", new[] { "Label_Id" });
            DropIndex("dbo.NoteLabels", new[] { "Note_Id" });
            DropTable("dbo.NoteLabels");
            DropTable("dbo.Labels");
        }
    }
}
