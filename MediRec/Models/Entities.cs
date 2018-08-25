using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Models
{
    public class Entities
    {
        [Key]
        public int EntityId { get; set; }

        [Required]
        [StringLength(4)]
        public string EntityCode { get; set; }

        [Required]
        public string NameAr { get; set; }

        [Required]
        public string NameEn { get; set; }

        public int CountryId { get; set; }

        public int CityId { get; set; }

        public int AreaId { get; set; }
    }
}