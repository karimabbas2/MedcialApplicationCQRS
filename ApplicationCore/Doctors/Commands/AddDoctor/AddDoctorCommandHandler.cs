using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.Email;
using ApplicationDomain;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Doctors.Commands.AddDoctor
{
    public class AddDoctorCommandHandler(IDoctorRepository doctorRepository, IDepartmentRepository departmentRepository, IDoctorDeptsRepository doctorDeptsRepository,
    IEmail email) : IRequestHandler<AddDoctorCommand, ServiceResponse>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IDoctorDeptsRepository _doctorDeptsRepository = doctorDeptsRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IEmail _email = email;

        public async Task<ServiceResponse> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddDoctorCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) throw new CustomValidationException(validationResult.Errors);
            Doctor newDoctor = new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Title = request.Title,
                Description = request.Description,
                Education = request.Education,
                Surname = request.Surname,
                Fee = request.Fee,
                Experience = request.Experience,
                Phone = request.Phone,
                Email = request.Email
            };

            if (await _doctorRepository.GetAsync(newDoctor.Id) is not null) return new ServiceResponse(false, "this Doctor is exist");
            await _doctorRepository.InsertAsync(newDoctor);

            if (request.DoctorDepartmentsIDs is not null)
            {
                foreach (var Id in request.DoctorDepartmentsIDs)
                {
                    var dept = await _departmentRepository.GetAsync(Id);
                    if (dept is not null)
                    {
                        DoctorDepartment doctorDepartment = new()
                        {
                            Id = Guid.NewGuid().ToString(),
                            DoctorId = newDoctor.Id,
                            DepartmentId = dept.Id
                        };
                        await _doctorDeptsRepository.InsertAsync(doctorDepartment);
                    }
                }
            }
            await _email.SendEmailAsync(request.Email, "Test", $"Welcome {request.Name} , this is Test");
            return new ServiceResponse(true, "New Doctor Added Successfully");
        }
    }
}