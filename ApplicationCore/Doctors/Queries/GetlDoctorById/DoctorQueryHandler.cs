using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces;
using MediatR;

namespace ApplicationCore.Doctors.Queries.GetlDoctorById
{
    public class DoctorQueryHandler(IDoctorRepository doctorRepository, IDepartmentRepository departmentRepository) : IRequestHandler<DoctorQuery, DoctoDto>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        public async Task<DoctoDto> Handle(DoctorQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(request.Id);
            var depts = await _departmentRepository.GetAllAsync();

            DoctoDto doctoDto = new()
            {
                Name = doctor.Name,
                Departments = depts
            };
            return doctoDto;
        }
    }
}