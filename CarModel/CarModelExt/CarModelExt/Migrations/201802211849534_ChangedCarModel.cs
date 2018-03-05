namespace CarModelExt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedCarModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModels", "DateCreate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CarModels", "CreateDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "CreateDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.CarModels", "DateCreate");
        }
    }
}
