﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MediRec.Models
{
    public class BloodPressure
    {
        [Key]
        public int BloodPressureId { get; set; }

        public double Systolic { get; set; }

        public double Diastolic { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}