namespace ManyToManyRelationship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmplAcadmics : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicHistories",
                c => new
                    {
                        AcademicHistoryId = c.Int(nullable: false, identity: true),
                        Degree = c.String(),
                        Institute = c.String(),
                        Subject = c.String(),
                        PassingYear = c.String(),
                    })
                .PrimaryKey(t => t.AcademicHistoryId);
            
            CreateTable(
                "dbo.EmployeeAcademicHistories",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        AcademicHistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.AcademicHistoryId })
                .ForeignKey("dbo.AcademicHistories", t => t.AcademicHistoryId, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.AcademicHistoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeAcademicHistories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.EmployeeAcademicHistories", "AcademicHistoryId", "dbo.AcademicHistories");
            DropIndex("dbo.EmployeeAcademicHistories", new[] { "AcademicHistoryId" });
            DropIndex("dbo.EmployeeAcademicHistories", new[] { "EmployeeId" });
            DropTable("dbo.EmployeeAcademicHistories");
            DropTable("dbo.AcademicHistories");
        }
    }
}
