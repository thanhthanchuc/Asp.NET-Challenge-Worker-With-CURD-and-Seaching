namespace Worker_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConstraintCanNull : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Workers", "ChangeSalaryId", "dbo.ChangeSalaries");
            DropIndex("dbo.Workers", new[] { "ChangeSalaryId" });
            AlterColumn("dbo.Workers", "ChangeSalaryId", c => c.Int());
            CreateIndex("dbo.Workers", "ChangeSalaryId");
            AddForeignKey("dbo.Workers", "ChangeSalaryId", "dbo.ChangeSalaries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workers", "ChangeSalaryId", "dbo.ChangeSalaries");
            DropIndex("dbo.Workers", new[] { "ChangeSalaryId" });
            AlterColumn("dbo.Workers", "ChangeSalaryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Workers", "ChangeSalaryId");
            AddForeignKey("dbo.Workers", "ChangeSalaryId", "dbo.ChangeSalaries", "Id", cascadeDelete: true);
        }
    }
}
