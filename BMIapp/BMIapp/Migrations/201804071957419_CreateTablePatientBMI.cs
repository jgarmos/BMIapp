namespace BMIapp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablePatientBMI : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PatientBMIs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Double(nullable: false),
                        Height = c.Double(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientBMIs", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PatientBMIs", new[] { "User_Id" });
            DropTable("dbo.PatientBMIs");
        }
    }
}
