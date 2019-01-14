namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_RentLessee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentLessees",
                c => new
                    {
                        LessorId = c.String(nullable: false, maxLength: 128),
                        LesseeId = c.String(nullable: false, maxLength: 128),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 256),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.LessorId, t.LesseeId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RentLessees");
        }
    }
}
