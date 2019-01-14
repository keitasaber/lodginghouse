namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLessorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lessors", "LodgingHouseName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Lessors", "LodgingHouseName");
        }
    }
}
