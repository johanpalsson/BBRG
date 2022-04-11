namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "Assessment_Id", c => c.Int());
            CreateIndex("dbo.Regions", "Assessment_Id");
            AddForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Regions", new[] { "Assessment_Id" });
            DropColumn("dbo.Regions", "Assessment_Id");
        }
    }
}
