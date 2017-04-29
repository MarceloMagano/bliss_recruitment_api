namespace bliss_recruitment_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Choice",
                c => new
                    {
                        ChoiceID = c.Int(nullable: false, identity: true),
                        choice = c.String(),
                        votes = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChoiceID)
                .ForeignKey("dbo.Question", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        question = c.String(),
                        image_url = c.String(),
                        thumb_url = c.String(),
                        published_at = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Choice", "QuestionID", "dbo.Question");
            DropIndex("dbo.Choice", new[] { "QuestionID" });
            DropTable("dbo.Question");
            DropTable("dbo.Choice");
        }
    }
}
