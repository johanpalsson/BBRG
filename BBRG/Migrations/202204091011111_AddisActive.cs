namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddisActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavingPlans", "IsActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SavingPlans", "IsActive");
        }
    }
}
