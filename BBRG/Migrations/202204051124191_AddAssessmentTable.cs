namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssessmentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assessments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AssessmentUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssessmentUser_Id)
                .Index(t => t.AssessmentUser_Id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Assessment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assessments", t => t.Assessment_Id)
                .Index(t => t.Assessment_Id);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments");
            DropForeignKey("dbo.Assessments", "AssessmentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Regions", new[] { "Assessment_Id" });
            DropIndex("dbo.Assessments", new[] { "AssessmentUser_Id" });
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.Regions");
            DropTable("dbo.Assessments");
        }
    }
}
