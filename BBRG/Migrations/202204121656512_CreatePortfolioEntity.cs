namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatePortfolioEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Portfolios",
                c => new
                    {
                        PortfolioId = c.Int(nullable: false, identity: true),
                        AssessmentUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PortfolioId)
                .ForeignKey("dbo.AspNetUsers", t => t.AssessmentUser_Id)
                .Index(t => t.AssessmentUser_Id);
            
            CreateTable(
                "dbo.SecurityTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SecTypeName = c.String(),
                        Portfolio_PortfolioId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Portfolios", t => t.Portfolio_PortfolioId)
                .Index(t => t.Portfolio_PortfolioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SecurityTypes", "Portfolio_PortfolioId", "dbo.Portfolios");
            DropForeignKey("dbo.Portfolios", "AssessmentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SecurityTypes", new[] { "Portfolio_PortfolioId" });
            DropIndex("dbo.Portfolios", new[] { "AssessmentUser_Id" });
            DropTable("dbo.SecurityTypes");
            DropTable("dbo.Portfolios");
        }
    }
}
