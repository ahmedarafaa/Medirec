namespace MediRec.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationBetweenEntitiesAndCountries : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Doctors", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Doctors", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Doctors", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.SpecialtiesDoctors", "Doctors_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.Immunizations", "VaccineId", "dbo.Vaccines");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Areas", "CityId", "dbo.Cities", "CityId");
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.Doctors", "AreaId", "dbo.Areas", "AreaId");
            AddForeignKey("dbo.Doctors", "CityId", "dbo.Cities", "CityId");
            AddForeignKey("dbo.Doctors", "CountryId", "dbo.Countries", "CountryId");
            AddForeignKey("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId", "dbo.Specialties", "SpecialtyId");
            AddForeignKey("dbo.SpecialtiesDoctors", "Doctors_DoctorId", "dbo.Doctors", "DoctorId");
            AddForeignKey("dbo.Immunizations", "VaccineId", "dbo.Vaccines", "VaccineId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Immunizations", "VaccineId", "dbo.Vaccines");
            DropForeignKey("dbo.SpecialtiesDoctors", "Doctors_DoctorId", "dbo.Doctors");
            DropForeignKey("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId", "dbo.Specialties");
            DropForeignKey("dbo.Doctors", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Doctors", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Doctors", "AreaId", "dbo.Areas");
            DropForeignKey("dbo.Cities", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Areas", "CityId", "dbo.Cities");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Immunizations", "VaccineId", "dbo.Vaccines", "VaccineId", cascadeDelete: true);
            AddForeignKey("dbo.SpecialtiesDoctors", "Doctors_DoctorId", "dbo.Doctors", "DoctorId", cascadeDelete: true);
            AddForeignKey("dbo.SpecialtiesDoctors", "Specialties_SpecialtyId", "dbo.Specialties", "SpecialtyId", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
            AddForeignKey("dbo.Doctors", "AreaId", "dbo.Areas", "AreaId", cascadeDelete: true);
            AddForeignKey("dbo.Cities", "CountryId", "dbo.Countries", "CountryId", cascadeDelete: true);
            AddForeignKey("dbo.Areas", "CityId", "dbo.Cities", "CityId", cascadeDelete: true);
        }
    }
}
