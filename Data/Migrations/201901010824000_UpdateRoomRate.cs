namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoomRate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RoomRates", "MonthlyRate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoomRates", "MonthlyRate", c => c.String(nullable: false));
        }
    }
}
