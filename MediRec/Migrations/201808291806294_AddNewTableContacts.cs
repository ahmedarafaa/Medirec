namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTableContacts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ContactId = c.Int(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 100),
                        TypeOfRelation = c.String(maxLength: 5),
                        PhoneNumber01 = c.String(nullable: false, maxLength: 11),
                        PhoneNumber02 = c.String(maxLength: 11),
                        Email = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ContactId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
