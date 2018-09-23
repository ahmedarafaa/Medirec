namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaymentTypesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaymentTypes",
                c => new
                    {
                        PaymentTypesId = c.Int(nullable: false, identity: true),
                        PaymentTypesCode = c.String(nullable: false, maxLength: 5),
                        NameAr = c.String(nullable: false, maxLength: 50),
                        NameEn = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.PaymentTypesId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PaymentTypes");
        }
    }
}
