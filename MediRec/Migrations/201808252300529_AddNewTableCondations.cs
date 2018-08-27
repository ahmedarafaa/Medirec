namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableCondations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condations",
                c => new
                    {
                        CondationsId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CondationsId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Condations");
        }
    }
}
