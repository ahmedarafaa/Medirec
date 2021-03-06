﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Dtos
{
    public class AreasDto
    {
        [Key]
        public int AreaId { get; set; }

        //[Required]
        [StringLength(4)]
        [Display(Name = "Area Code")]
        public string AreaCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Arabic Name")]
        public string NameAr { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "English Name")]
        public string NameEn { get; set; }

        public int CityId { get; set; }
    }
}