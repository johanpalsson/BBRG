namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Regions", new[] { "Assessment_Id" });
            AddColumn("dbo.Assessments", "Region_Id", c => c.Int());
            CreateIndex("dbo.Assessments", "Region_Id");
            AddForeignKey("dbo.Assessments", "Region_Id", "dbo.Regions", "Id");
            DropColumn("dbo.Regions", "Assessment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "Assessment_Id", c => c.Int());
            DropForeignKey("dbo.Assessments", "Region_Id", "dbo.Regions");
            DropIndex("dbo.Assessments", new[] { "Region_Id" });
            DropColumn("dbo.Assessments", "Region_Id");
            CreateIndex("dbo.Regions", "Assessment_Id");
            AddForeignKey("dbo.Regions", "Assessment_Id", "dbo.Assessments", "Id");
        }
    }
}
