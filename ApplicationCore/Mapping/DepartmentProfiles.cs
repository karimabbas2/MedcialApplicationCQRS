using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationDomain;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class DepartmentProfiles : Profile
    {
        public DepartmentProfiles()
        {
            CreateMap<Department, DepartmentListDto>()
             .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.DoctorDepartments.Where(x => x.DepartmentId == src.Id)
             .Select(c => c.Doctor.Name)
             .ToList()))
             
            .ForMember(dest => dest.CreadtedAt, opt => opt.MapFrom(src => src.CreatedAt));

        }

    }
}