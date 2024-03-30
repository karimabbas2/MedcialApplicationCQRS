using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationCore.Doctors.Commands.AddDoctor;
using ApplicationCore.Doctors.Queries;
using ApplicationCore.Doctors.Queries.GetlDoctorById;
using ApplicationDomain;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //Doctor
            CreateMap<Doctor, AddDoctorCommand>()
            .ReverseMap()
            .AfterMap((src, dest) => dest.Name = $"Dr.{src.Name}");

            CreateMap<Doctor, DoctorListDto>()
            .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.DoctorDepartments.Where(x => x.DoctorId == src.Id)
            .Select(x => x.Department.Name).ToList()));

            CreateMap<Doctor, DoctorListDto>()
            .ForMember(dest => dest.Departments, opt => opt.MapFrom(src => src.DoctorDepartments.Where(x => x.DoctorId == src.Id)
            .Select(c => c.Department.Name)
            .ToList()));

        }
    }
}