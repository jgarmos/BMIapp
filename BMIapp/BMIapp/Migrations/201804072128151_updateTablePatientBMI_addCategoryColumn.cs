namespace BMIapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTablePatientBMI_addCategoryColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientBMIs", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientBMIs", "Category");
        }
    }
}
