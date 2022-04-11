namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updates2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assessments", "RegionId", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assessments", "RegionId");
        }
    }
}
