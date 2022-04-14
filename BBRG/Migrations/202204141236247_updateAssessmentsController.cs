namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAssessmentsController : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assessments", "PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Assessments", new[] { "PortfolioId" });
            AddColumn("dbo.Assessments", "Portfolio_PortfolioId", c => c.Int());
            AddColumn("dbo.Portfolios", "Assessment_Id", c => c.Int());
            CreateIndex("dbo.Assessments", "Portfolio_PortfolioId");
            CreateIndex("dbo.Portfolios", "Assessment_Id");
            AddForeignKey("dbo.Portfolios", "Assessment_Id", "dbo.Assessments", "Id");
            AddForeignKey("dbo.Assessments", "Portfolio_PortfolioId", "dbo.Portfolios", "PortfolioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "Assessment_Id", "dbo.Assessments");
            DropIndex("dbo.Portfolios", new[] { "Assessment_Id" });
            DropIndex("dbo.Assessments", new[] { "Portfolio_PortfolioId" });
            DropColumn("dbo.Portfolios", "Assessment_Id");
            DropColumn("dbo.Assessments", "Portfolio_PortfolioId");
            CreateIndex("dbo.Assessments", "PortfolioId");
            AddForeignKey("dbo.Assessments", "PortfolioId", "dbo.Portfolios", "PortfolioId", cascadeDelete: true);
        }
    }
}
