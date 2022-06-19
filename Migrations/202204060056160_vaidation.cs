namespace MyProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vaidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.HizmetForms", "TelNo", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
           // AlterColumn("dbo.HizmetForms", "TelNo", c => c.String(nullable: false));
            AlterColumn("dbo.HizmetForms", "TelNo", c => c.Int(nullable: false));
        }
    }
}
