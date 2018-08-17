using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Dtos
{
    public class DoctorsDto
    {
        [Key]
        public int DoctorId { get; set; }

        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public byte Specialty { get; set; }

        public byte CountryId { get; set; }

        public byte CityId { get; set; }

        public string SearchName { get; set; }
    }
}