namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreadtedDateTimeIntoResources : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resources", "CreadtedDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resources", "CreadtedDateTime");
        }
    }
}
