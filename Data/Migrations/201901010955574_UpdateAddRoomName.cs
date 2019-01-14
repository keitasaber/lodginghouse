namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAddRoomName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoomRates", "RoomName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoomRates", "RoomName");
        }
    }
}
