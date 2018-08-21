using MediRec.Models;
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

        [Required]
        [StringLength(5)]
        public string DoctorCode { get; set; }

        [Required]
        [StringLength(100)]
        public string NameAr { get; set; }

        [Required]
        [StringLength(100)]
        public string NameEn { get; set; }


        [Required]
        public byte SpecialtyId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int AreaId { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        public double TickerPrice { get; set; }

        [StringLength(100)]
        public string AboutDoctorShortDescription { get; set; }

        [StringLength(1000)]
        public string AboutDoctorLongDescription { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }

    }
}