namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addApproveOvertime : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Approvals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Approval_Status = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                        Overtimes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .ForeignKey("dbo.Overtimes", t => t.Overtimes_Id)
                .Index(t => t.Employees_Id)
                .Index(t => t.Overtimes_Id);
            
            CreateTable(
                "dbo.Overtimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Check_In = c.DateTimeOffset(nullable: false, precision: 7),
                        Check_Out = c.DateTimeOffset(nullable: false, precision: 7),
                        Overtime_Salary = c.Int(nullable: false),
                        Difference = c.Int(nullable: false),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Employees_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employees_Id)
                .Index(t => t.Employees_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Approvals", "Overtimes_Id", "dbo.Overtimes");
            DropForeignKey("dbo.Overtimes", "Employees_Id", "dbo.Employees");
            DropForeignKey("dbo.Approvals", "Employees_Id", "dbo.Employees");
            DropIndex("dbo.Overtimes", new[] { "Employees_Id" });
            DropIndex("dbo.Approvals", new[] { "Overtimes_Id" });
            DropIndex("dbo.Approvals", new[] { "Employees_Id" });
            DropTable("dbo.Overtimes");
            DropTable("dbo.Approvals");
        }
    }
}
