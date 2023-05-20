namespace CodeFirstModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second_Migration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.TagCourses");
            AddPrimaryKey("dbo.TagCourses", new[] { "Course_Id", "Tag_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TagCourses");
            AddPrimaryKey("dbo.TagCourses", new[] { "Tag_Id", "Course_Id" });
        }
    }
}
