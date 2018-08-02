namespace Worker_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnWantedForeignKey : DbMigration
    {
        public override void Up()
        {
            Sql(@"ALTER TABLE Workers DROP CONSTRAINT [FK_dbo.Workers_dbo.ChangeSalaries_ChangeSalaryId]");
        }
        
        public override void Down()
        {
        }
    }
}
