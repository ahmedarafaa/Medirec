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
            Mapper.CreateMap<Patients, PatientsDto>();
            Mapper.CreateMap<Allergies, AllergiesDto>();
            Mapper.CreateMap<Condations, CondationsDto>();
            Mapper.CreateMap<HumanBody, HumanBodyDto>();
            Mapper.CreateMap<BloodPressure, BloodPressureDto>();

            //Dto to Domain 

            Mapper.CreateMap<DoctorsDto, Doctors>();
            Mapper.CreateMap<PatientsDto, Patients>();
            Mapper.CreateMap<AllergiesDto, Allergies>();
            Mapper.CreateMap<CondationsDto, Condations>();
            Mapper.CreateMap<HumanBodyDto, HumanBody>();
            Mapper.CreateMap<BloodPressureDto, BloodPressure>();

        }
    }
}