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

        [Required]
        public byte SpecialtyId { get; set; }

        [Required]
        public int CityId { get; set; }
        public Cities Cities { get; set; }

        [Required]
        public int AreaId { get; set; }
        public Areas Areas { get; set; }

        [Required]
        [StringLength(1)]
        public string Gender { get; set; }

        [Required]
        [StringLength(225)]
        public string SearchName { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }
}