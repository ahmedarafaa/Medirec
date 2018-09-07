using MediRec.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Dtos
{
    public class DoctorsDtoSearch
    {

        [Key]
        public int DoctorId { get; set; }

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

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [Required]
        public int WaitingTime { get; set; }

        [Required]
        [StringLength(225)]
        public string SearchName { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}