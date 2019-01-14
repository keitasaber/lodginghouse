namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomRates", "From", c => c.DateTime());
            AlterColumn("dbo.RoomRates", "To", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomRates", "To", c => c.DateTime(nullable: false));
            AlterColumn("dbo.RoomRates", "From", c => c.DateTime(nullable: false));
        }
    }
}
