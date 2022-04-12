namespace BBRG.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSecuritiesTypesToEntity : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO SecurityTypes (SecTypeName) VALUES ('Fund')");
            Sql("INSERT INTO SecurityTypes (SecTypeName) VALUES ('Share')");
            Sql("INSERT INTO SecurityTypes (SecTypeName) VALUES ('Bond')");
        }
        
        public override void Down()
        {
        }
    }
}
