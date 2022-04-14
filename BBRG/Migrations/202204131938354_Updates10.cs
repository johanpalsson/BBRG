namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assessments", "Portfolio_PortfolioId", c => c.Int());
            CreateIndex("dbo.Assessments", "Portfolio_PortfolioId");
            AddForeignKey("dbo.Assessments", "Portfolio_PortfolioId", "dbo.Portfolios", "PortfolioId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assessments", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropIndex("dbo.Assessments", new[] { "Portfolio_PortfolioId" });
            DropColumn("dbo.Assessments", "Portfolio_PortfolioId");
        }
    }
}
