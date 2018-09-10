﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MediRec.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Doctors> Doctors { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Areas> Areas { get; set; }
        public DbSet<Specialties> Specialties { get; set; }
        public DbSet<BookingType> BookingType { get; set; }
        public DbSet<Entities> Entities { get; set; }
        public DbSet<EntitiesDoctors> EntitiesDoctors { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Allergies> Allergies { get; set; }
        public DbSet<Condations> Condations { get; set; }
        public DbSet<HumanBody> HumanBody { get; set; }
        public DbSet<BloodPressure> BloodPressure { get; set; }
        public DbSet<Medications> Medications { get; set; }
        public DbSet<MedicalDevices> MedicalDevices { get; set; }
        public DbSet<Resources> Resources { get; set; }
        public DbSet<Contacts> Contacts { get; set; }
        public DbSet<Vaccines> Vaccines { get; set; }
        public DbSet<Immunizations> Immunizations { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Add<CascadeDeleteAttributeConvention>();
        }

        //public System.Data.Entity.DbSet<MediRec.Models.Allergies> Allergies { get; set; }

        //public System.Data.Entity.DbSet<MediRec.ViewModel.RoleViewModel> RoleViewModels { get; set; }
    }
}