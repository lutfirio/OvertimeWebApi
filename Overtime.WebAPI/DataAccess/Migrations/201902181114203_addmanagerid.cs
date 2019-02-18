namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmanagerid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Managers_Id", "dbo.Employees");
            DropIndex("dbo.Employees", new[] { "Managers_Id" });
            AlterColumn("dbo.Employees", "Managers_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Managers_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Managers_Id");
            AddForeignKey("dbo.Employees", "Managers_Id", "dbo.Employees", "Id");
        }
    }
}
