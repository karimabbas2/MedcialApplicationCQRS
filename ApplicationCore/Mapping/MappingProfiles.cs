using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Doctors.Commands.AddDoctor;
using ApplicationDomain;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<AddDoctorCommand, Doctor>();
            // CreateMap<Doctor, AddDoctorCommand>();
        }
    }
}