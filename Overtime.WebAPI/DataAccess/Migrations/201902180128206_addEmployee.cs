namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEmployee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "Districts_Id", "dbo.Districts");
            DropForeignKey("dbo.Employees", "Provinces_Id", "dbo.Provinces");
            DropForeignKey("dbo.Employees", "Regencies_Id", "dbo.Regencies");
            DropIndex("dbo.Employees", new[] { "Districts_Id" });
            DropIndex("dbo.Employees", new[] { "Provinces_Id" });
            DropIndex("dbo.Employees", new[] { "Regencies_Id" });
            AddColumn("dbo.Employees", "Villages_Id", c => c.Int());
            CreateIndex("dbo.Employees", "Villages_Id");
            AddForeignKey("dbo.Employees", "Villages_Id", "dbo.Villages", "Id");
            DropColumn("dbo.Employees", "Villages");
            DropColumn("dbo.Employees", "Districts_Id");
            DropColumn("dbo.Employees", "Provinces_Id");
            DropColumn("dbo.Employees", "Regencies_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Regencies_Id", c => c.Int());
            AddColumn("dbo.Employees", "Provinces_Id", c => c.Int());
            AddColumn("dbo.Employees", "Districts_Id", c => c.Int());
            AddColumn("dbo.Employees", "Villages", c => c.Int(nullable: false));
            DropForeignKey("dbo.Employees", "Villages_Id", "dbo.Villages");
            DropIndex("dbo.Employees", new[] { "Villages_Id" });
            DropColumn("dbo.Employees", "Villages_Id");
            CreateIndex("dbo.Employees", "Regencies_Id");
            CreateIndex("dbo.Employees", "Provinces_Id");
            CreateIndex("dbo.Employees", "Districts_Id");
            AddForeignKey("dbo.Employees", "Regencies_Id", "dbo.Regencies", "Id");
            AddForeignKey("dbo.Employees", "Provinces_Id", "dbo.Provinces", "Id");
            AddForeignKey("dbo.Employees", "Districts_Id", "dbo.Districts", "Id");
        }
    }
}
