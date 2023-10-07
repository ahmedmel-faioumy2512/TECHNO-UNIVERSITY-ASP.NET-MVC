namespace MVC_Training.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "CourseCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "CourseCode");
        }
    }
}

