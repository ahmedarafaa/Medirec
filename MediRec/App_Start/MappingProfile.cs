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
            Mapper.CreateMap<Medications, MedicationsDto>();
            Mapper.CreateMap<MedicalDevices, MedicalDevicesDto>();
            Mapper.CreateMap<Resources, ResourcesDto>();
            Mapper.CreateMap<Contacts, ContactsDto>();
            Mapper.CreateMap<Vaccines, VaccinesDto>();
            Mapper.CreateMap<Immunizations, ImmunizationsDto>();

            //Dto to Domain 

            Mapper.CreateMap<DoctorsDto, Doctors>();
            Mapper.CreateMap<PatientsDto, Patients>();
            Mapper.CreateMap<AllergiesDto, Allergies>();
            Mapper.CreateMap<CondationsDto, Condations>();
            Mapper.CreateMap<HumanBodyDto, HumanBody>();
            Mapper.CreateMap<BloodPressureDto, BloodPressure>();
            Mapper.CreateMap<MedicationsDto, Medications>();
            Mapper.CreateMap<MedicalDevicesDto, MedicalDevices>();
            Mapper.CreateMap<ResourcesDto, Resources>();
            Mapper.CreateMap<ContactsDto, Contacts>();
            Mapper.CreateMap<VaccinesDto, Vaccines>();
            Mapper.CreateMap<ImmunizationsDto, Immunizations>();

        }
    }
}