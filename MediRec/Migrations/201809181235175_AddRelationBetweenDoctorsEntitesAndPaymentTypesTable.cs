namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenDoctorsEntitesAndPaymentTypesTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.DoctorsEntities");
            AddColumn("dbo.DoctorsEntities", "PaymentTypesId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.DoctorsEntities", new[] { "DoctorId", "EntityId", "PaymentTypesId" });
            CreateIndex("dbo.DoctorsEntities", "PaymentTypesId");
            AddForeignKey("dbo.DoctorsEntities", "PaymentTypesId", "dbo.PaymentTypes", "PaymentTypesId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DoctorsEntities", "PaymentTypesId", "dbo.PaymentTypes");
            DropIndex("dbo.DoctorsEntities", new[] { "PaymentTypesId" });
            DropPrimaryKey("dbo.DoctorsEntities");
            DropColumn("dbo.DoctorsEntities", "PaymentTypesId");
            AddPrimaryKey("dbo.DoctorsEntities", new[] { "DoctorId", "EntityId" });
        }
    }
}
