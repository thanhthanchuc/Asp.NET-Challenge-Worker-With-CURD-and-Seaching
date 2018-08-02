namespace Worker_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcontraint : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "ChangeSalaryId", "dbo.ChangeSalaries");
            DropIndex("dbo.Workers", new[] { "ChangeSalaryId" });
            AddColumn("dbo.ChangeSalaries", "WorkerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ChangeSalaries", "WorkerId");
            AddForeignKey("dbo.ChangeSalaries", "WorkerId", "dbo.Workers", "Id", cascadeDelete: true);
            DropColumn("dbo.Workers", "ChangeSalaryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Workers", "ChangeSalaryId", c => c.Int());
            DropForeignKey("dbo.ChangeSalaries", "WorkerId", "dbo.Workers");
            DropIndex("dbo.ChangeSalaries", new[] { "WorkerId" });
            DropColumn("dbo.ChangeSalaries", "WorkerId");
            CreateIndex("dbo.Workers", "ChangeSalaryId");
            AddForeignKey("dbo.Workers", "ChangeSalaryId", "dbo.ChangeSalaries", "Id");
        }
    }
}
