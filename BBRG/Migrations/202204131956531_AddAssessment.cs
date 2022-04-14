namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAssessment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assessments", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans");
            DropIndex("dbo.Assessments", new[] { "Portfolio_PortfolioId" });
            DropIndex("dbo.Assessments", new[] { "SavingPlan_Id" });
            RenameColumn(table: "dbo.Assessments", name: "Portfolio_PortfolioId", newName: "PortfolioId");
            RenameColumn(table: "dbo.Assessments", name: "SavingPlan_Id", newName: "SavingPlanId");
            AddColumn("dbo.Assessments", "SecurityTypeId", c => c.Int(nullable: true));
            AddColumn("dbo.SecurityTypes", "Assessment_Id", c => c.Int());
            AddColumn("dbo.SavingPlans", "Assessment_Id", c => c.Int());
            AlterColumn("dbo.Assessments", "PortfolioId", c => c.Int(nullable: true));
            AlterColumn("dbo.Assessments", "SavingPlanId", c => c.Int(nullable: true));
            CreateIndex("dbo.Assessments", "SavingPlanId");
            CreateIndex("dbo.Assessments", "PortfolioId");
            CreateIndex("dbo.Assessments", "SecurityTypeId");
            CreateIndex("dbo.SecurityTypes", "Assessment_Id");
            CreateIndex("dbo.SavingPlans", "Assessment_Id");
            AddForeignKey("dbo.SavingPlans", "Assessment_Id", "dbo.Assessments", "Id");
            AddForeignKey("dbo.Assessments", "SecurityTypeId", "dbo.SecurityTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SecurityTypes", "Assessment_Id", "dbo.Assessments", "Id");
            AddForeignKey("dbo.Assessments", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
            AddForeignKey("dbo.Assessments", "SavingPlanId", "dbo.SavingPlans", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "SavingPlanId", "dbo.SavingPlans");
            DropForeignKey("dbo.Assessments", "PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.SecurityTypes", "Assessment_Id", "dbo.Assessments");
            DropForeignKey("dbo.Assessments", "SecurityTypeId", "dbo.SecurityTypes");
            DropForeignKey("dbo.SavingPlans", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.SavingPlans", new[] { "Assessment_Id" });
            DropIndex("dbo.SecurityTypes", new[] { "Assessment_Id" });
            DropIndex("dbo.Assessments", new[] { "SecurityTypeId" });
            DropIndex("dbo.Assessments", new[] { "PortfolioId" });
            DropIndex("dbo.Assessments", new[] { "SavingPlanId" });
            AlterColumn("dbo.Assessments", "SavingPlanId", c => c.Int());
            AlterColumn("dbo.Assessments", "PortfolioId", c => c.Int());
            DropColumn("dbo.SavingPlans", "Assessment_Id");
            DropColumn("dbo.SecurityTypes", "Assessment_Id");
            DropColumn("dbo.Assessments", "SecurityTypeId");
            RenameColumn(table: "dbo.Assessments", name: "SavingPlanId", newName: "SavingPlan_Id");
            RenameColumn(table: "dbo.Assessments", name: "PortfolioId", newName: "Portfolio_PortfolioId");
            CreateIndex("dbo.Assessments", "SavingPlan_Id");
            CreateIndex("dbo.Assessments", "Portfolio_PortfolioId");
            AddForeignKey("dbo.Assessments", "SavingPlan_Id", "dbo.SavingPlans", "Id");
            AddForeignKey("dbo.Assessments", "Portfolio_PortfolioId", "dbo.Portfolios", "PortfolioId");
        }
    }
}
