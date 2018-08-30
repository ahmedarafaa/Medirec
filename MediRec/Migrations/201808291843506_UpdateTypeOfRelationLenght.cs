namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTypeOfRelationLenght : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "TypeOfRelation", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "TypeOfRelation", c => c.String(maxLength: 5));
        }
    }
}
