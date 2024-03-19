using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces;
using MediatR;

namespace ApplicationCore.Doctors.Queries
{
    public class GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository,
    IDepartmentRepository departmentRepository,
    IDoctorDeptsRepository doctorDeptsRepository,
    IAppointmentRepoistory appointmentRepoistory) : IRequestHandler<GetAllDoctorsQuery, List<DoctorListDto>>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IDoctorDeptsRepository _doctorDeptsRepository = doctorDeptsRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IAppointmentRepoistory _appointmentRepoistory = appointmentRepoistory;
        public async Task<List<DoctorListDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync();
            var docDep = await _doctorDeptsRepository.GetAllAsync();
            var allAppointments = await _appointmentRepoistory.GetAllAsync();
            // var deps = await _departmentRepository.GetAllAsync();

            return doctors.Select(doctor => new DoctorListDto
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Title = doctor.Title,
                Email = doctor.Email,
                Experience = doctor.Experience,
                Phone = doctor.Phone,
                Education = doctor.Education,
                Fee = doctor.Fee,
                Description = doctor.Description,
                DoctorDepartments = docDep.Where(x => x.DoctorId == doctor.Id).ToList(),
                Appointments = allAppointments.Where(x => x.DoctorId == doctor.Id).ToList()

            }).ToList();
        }
    }
}