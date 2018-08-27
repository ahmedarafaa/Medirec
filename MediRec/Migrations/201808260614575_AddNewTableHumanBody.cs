namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableHumanBody : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HumanBodies",
                c => new
                    {
                        HumanBodyId = c.Int(nullable: false, identity: true),
                        Height = c.Double(nullable: false),
                        Weight = c.Double(nullable: false),
                        Date = c.DateTime(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HumanBodyId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HumanBodies");
        }
    }
}
