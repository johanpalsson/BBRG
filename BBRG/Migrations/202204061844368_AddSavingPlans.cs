namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSavingPlans : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ModelNomeTels", "ModelRecebe_Id", "dbo.ModelRecebes");
            DropIndex("dbo.ModelNomeTels", new[] { "ModelRecebe_Id" });
            CreateTable(
                "dbo.SavingPlans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RegionId = c.Byte(nullable: false),
                        AssessmentUser_Id = c.String(maxLength: 128),
                        Region_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AssessmentUser_Id)
                .ForeignKey("dbo.Regions", t => t.Region_Id)
                .Index(t => t.AssessmentUser_Id)
                .Index(t => t.Region_Id);
            
            AddColumn("dbo.Regions", "SavingPlan_Id", c => c.Int());
            CreateIndex("dbo.Regions", "SavingPlan_Id");
            AddForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans", "Id");
            DropTable("dbo.ModelRecebes");
            DropTable("dbo.ModelNomeTels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ModelNomeTels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        ModelRecebe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelRecebes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Regions", "SavingPlan_Id", "dbo.SavingPlans");
            DropForeignKey("dbo.SavingPlans", "Region_Id", "dbo.Regions");
            DropForeignKey("dbo.SavingPlans", "AssessmentUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SavingPlans", new[] { "Region_Id" });
            DropIndex("dbo.SavingPlans", new[] { "AssessmentUser_Id" });
            DropIndex("dbo.Regions", new[] { "SavingPlan_Id" });
            DropColumn("dbo.Regions", "SavingPlan_Id");
            DropTable("dbo.SavingPlans");
            CreateIndex("dbo.ModelNomeTels", "ModelRecebe_Id");
            AddForeignKey("dbo.ModelNomeTels", "ModelRecebe_Id", "dbo.ModelRecebes", "Id");
        }
    }
}
