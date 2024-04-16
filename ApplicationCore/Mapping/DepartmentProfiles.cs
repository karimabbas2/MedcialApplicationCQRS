using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Departments.Commands.AddDepartment;
using ApplicationCore.Departments.Commands.UpdateDepartment;
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
             .ForMember(dest => dest.Doctors, opt => opt.MapFrom(src => src.Doctors.Where(x => x.Department.Id == src.Id)
             .Select(c => c.Name)
             .ToList()))
             .ForMember(dest => dest.CreadtedAt, opt => opt.MapFrom(src => src.CreatedAt));

            CreateMap<AddDepartmentCommand, Department>();

            CreateMap<UpdateDepartmentCommand, Department>();


        }

    }
}