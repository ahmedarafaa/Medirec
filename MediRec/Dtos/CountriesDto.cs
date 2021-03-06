﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Dtos
{
    public class CountriesDto
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [StringLength(4)]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Arabic Name")]
        public string NameAr { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "English Name")]
        public string NameEn { get; set; }

        
    }
}