namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ModelRecebes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ModelNomeTels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Telefone = c.String(),
                        ModelRecebe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ModelRecebes", t => t.ModelRecebe_Id)
                .Index(t => t.ModelRecebe_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelNomeTels", "ModelRecebe_Id", "dbo.ModelRecebes");
            DropIndex("dbo.ModelNomeTels", new[] { "ModelRecebe_Id" });
            DropTable("dbo.ModelNomeTels");
            DropTable("dbo.ModelRecebes");
        }
    }
}
