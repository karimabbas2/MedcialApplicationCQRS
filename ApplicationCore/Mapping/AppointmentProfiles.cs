using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Appointment.Queries.GetAllApointment;
using AutoMapper;
using ApplicationDomain;
using ApplicationCore.Appointment.Commands.Command;
namespace ApplicationCore.Mapping
{
    public class AppointmentProfiles : Profile
    {
        public AppointmentProfiles()
        {
            //Add 
            CreateMap<MakeAppointmentCommand, ApplicationDomain.Appointment>();

            //Update
            CreateMap<UpdateAppointmentCommand, ApplicationDomain.Appointment>();
            // .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentID));

            //get
            CreateMap<ApplicationDomain.Appointment, AppointmentsDto>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.Name));

        }
    }
}