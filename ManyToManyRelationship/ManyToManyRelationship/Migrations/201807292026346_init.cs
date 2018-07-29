namespace ManyToManyRelationship.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmployeeAcademicHistories", "AcademicHistoryId", "dbo.AcademicHistories");
            DropForeignKey("dbo.EmployeeAcademicHistories", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.EmployeeAcademicHistories", new[] { "EmployeeId" });
            DropIndex("dbo.EmployeeAcademicHistories", new[] { "AcademicHistoryId" });
            CreateTable(
                "dbo.ProjectAssigns",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProjectId })
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            AddColumn("dbo.AcademicHistories", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.AcademicHistories", "EmployeeId");
            AddForeignKey("dbo.AcademicHistories", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            DropTable("dbo.EmployeeAcademicHistories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeeAcademicHistories",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false),
                        AcademicHistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.AcademicHistoryId });
            
            DropForeignKey("dbo.AcademicHistories", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.ProjectAssigns", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectAssigns", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ProjectAssigns", new[] { "ProjectId" });
            DropIndex("dbo.ProjectAssigns", new[] { "EmployeeId" });
            DropIndex("dbo.AcademicHistories", new[] { "EmployeeId" });
            DropColumn("dbo.AcademicHistories", "EmployeeId");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectAssigns");
            CreateIndex("dbo.EmployeeAcademicHistories", "AcademicHistoryId");
            CreateIndex("dbo.EmployeeAcademicHistories", "EmployeeId");
            AddForeignKey("dbo.EmployeeAcademicHistories", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
            AddForeignKey("dbo.EmployeeAcademicHistories", "AcademicHistoryId", "dbo.AcademicHistories", "AcademicHistoryId", cascadeDelete: true);
        }
    }
}
