namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.SavingPlans", new[] { "AssessmentUser_Id" });
            AddColumn("dbo.Assessments", "SavingPlan_Id", c => c.Int());
            AlterColumn("dbo.SavingPlans", "AssessmentUser_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Assessments", "SavingPlan_Id");
            CreateIndex("dbo.SavingPlans", "AssessmentUser_Id");
            AddForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans");
            DropIndex("dbo.SavingPlans", new[] { "AssessmentUser_Id" });
            DropIndex("dbo.Assessments", new[] { "SavingPlan_Id" });
            AlterColumn("dbo.SavingPlans", "AssessmentUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Assessments", "SavingPlan_Id");
            CreateIndex("dbo.SavingPlans", "AssessmentUser_Id");
        }
    }
}
