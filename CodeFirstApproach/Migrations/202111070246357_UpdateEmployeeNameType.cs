namespace CodeFirstApproach.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEmployeeNameType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeModels", "EmpName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeModels", "EmpName", c => c.Int(nullable: false));
        }
    }
}
