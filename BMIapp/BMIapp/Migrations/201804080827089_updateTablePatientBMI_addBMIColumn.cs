namespace BMIapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateTablePatientBMI_addBMIColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PatientBMIs", "BMI", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PatientBMIs", "BMI");
        }
    }
}
