namespace Worker_Assignment.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateForChangeSalary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChangeSalaries", "DateChanged", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChangeSalaries", "DateChanged");
        }
    }
}
