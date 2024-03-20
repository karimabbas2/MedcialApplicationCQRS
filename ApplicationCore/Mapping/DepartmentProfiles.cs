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
          .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.DoctorDepartments.Where(d => d.DepartmentId == src.Id)
          .Select(x => x.Doctor.Name).ToList()));
        }

    }
}