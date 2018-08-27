using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Models
{
    public class Patients
    {
        [Key]
        public int PatientId { get; set; }

        public int UserId { get; set; }

        [StringLength(4)]
        public string PatientCode { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int AreaId { get; set; }

        public int InsuranceId { get; set; }

        [StringLength(1500)]
        public string ImageURL { get; set; }

        [StringLength(225)]
        public string CreatedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreadtedDateTime { get; set; }

        [StringLength(225)]
        public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ModifiedDateTime { get; set; }

    }
}