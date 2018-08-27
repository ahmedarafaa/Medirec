using System.Data.Entity;
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

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<MediRec.Models.Allergies> Allergies { get; set; }

        //public System.Data.Entity.DbSet<MediRec.ViewModel.RoleViewModel> RoleViewModels { get; set; }
    }
}