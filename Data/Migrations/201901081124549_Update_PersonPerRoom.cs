namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_PersonPerRoom : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PersonPerRooms");
            AlterColumn("dbo.PersonPerRooms", "RoomId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PersonPerRooms", new[] { "LessorId", "RoomId", "LesseeId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PersonPerRooms");
            AlterColumn("dbo.PersonPerRooms", "RoomId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PersonPerRooms", new[] { "LessorId", "RoomId", "LesseeId" });
        }
    }
}
