namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addvillage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Villages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateDate = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteDate = c.DateTimeOffset(nullable: false, precision: 7),
                        IsDelete = c.Boolean(nullable: false),
                        Districts_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Districts", t => t.Districts_Id)
                .Index(t => t.Districts_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Villages", "Districts_Id", "dbo.Districts");
            DropIndex("dbo.Villages", new[] { "Districts_Id" });
            DropTable("dbo.Villages");
        }
    }
}
