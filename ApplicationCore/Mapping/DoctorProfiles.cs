using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Departments.Queries.GetAllDepartments;
using ApplicationCore.Doctors.Command.Commands;
using ApplicationCore.Doctors.Commands.AddDoctor;
using ApplicationCore.Doctors.Queries;
using ApplicationCore.Doctors.Queries.GetlDoctorById;
using ApplicationDomain;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class DoctorProfiles : Profile
    {
        public DoctorProfiles()
        {
            //Add Doctor
            CreateMap<AddDoctorCommand, Doctor>()
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentID))
            .AfterMap((src, dest) => dest.Name = $"Dr.{src.Name}");

            //Update
            CreateMap<UpdateDoctorCommand, Doctor>()
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentID));

            //Get single/list of Doctors
            CreateMap<Doctor, DoctorListDto>()
            .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Name))
            .ForMember(dest => dest.DepartmentID, opt => opt.MapFrom(src => src.Department.Id))

            .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments.Where(x => x.Doctor.Id == src.Id)
            .Select(x => new { x.ResevtionDate, x.AppointmentStatus }).ToList()));

        }
    }
}