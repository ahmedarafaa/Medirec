using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Models
{
    public class EntitiesDoctors
    {
        [Key]
        public int EntitiesDoctorsId { get; set; }

        public string DoctorId { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int AreaId { get; set; }

        public int EntityId { get; set; }
    }
}