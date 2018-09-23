namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToEntitiesTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Entities", "Address", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Entities", "Address");
        }
    }
}
