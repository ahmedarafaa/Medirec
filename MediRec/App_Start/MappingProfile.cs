using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MediRec.Dtos;
using MediRec.Models;

namespace MediRec.App_Start
{
    public class MappingProfile : Profile
    {
        
        public MappingProfile()
        {
            //Domain to Dto
            Mapper.CreateMap<Doctors, DoctorsDto>();


            //Dto to Domain 

            Mapper.CreateMap<DoctorsDto, Doctors>();
        }
    }
}