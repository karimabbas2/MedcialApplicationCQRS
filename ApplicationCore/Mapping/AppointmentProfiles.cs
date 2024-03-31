using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Appointment.Queries.GetAllApointment;
using AutoMapper;

namespace ApplicationCore.Mapping
{
    public class AppointmentProfiles : Profile
    {
        public AppointmentProfiles()
        {
            //Add , update
            CreateMap<MakeAppointmentCommand, ApplicationDomain.Appointment>();

            //get
            CreateMap<ApplicationDomain.Appointment, AppointmentsDto>()
            .ForMember(dest => dest.Doctor, opt => opt.MapFrom(src => src.Doctor.Name));
        }
    }
}