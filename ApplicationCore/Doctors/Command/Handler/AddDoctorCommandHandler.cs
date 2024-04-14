using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Doctors.Command.Commands;
using ApplicationCore.Doctors.Queries;
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
    IEmail email, IMapper mapper) :
     IRequestHandler<AddDoctorCommand, ResponseResult<object>>,
     IRequestHandler<DeleteDoctorCommand, ResponseResult<string>>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IDoctorDeptsRepository _doctorDeptsRepository = doctorDeptsRepository;
        private readonly IDepartmentRepository _departmentRepository = departmentRepository;
        private readonly IEmail _email = email;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseResult<object>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddDoctorCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors<object>(validationResult.Errors[0].ToString());

            var newDoctor = _mapper.Map<Doctor>(request);

            if (await _doctorRepository.GetAsync(newDoctor.Id) is not null) return ResponseHandler.Conflicted<object>("this Doctor is exist");

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
            // await _email.SendEmailAsync(request.Email, "Test", $"Welcome {request.Name} , this is Test");
            var result = _mapper.Map<DoctorListDto>(newDoctor);
            return ResponseHandler.Created<object>(result);
        }

        public async Task<ResponseResult<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            // if (await _doctorRepository.GetAsync(request.Id) is null) return ResponseHandler.NotFound<string>("No Department with this Id");
            await _doctorRepository.DeleteAsync(request.Id);
            return ResponseHandler.Success("Doctor Deleted Successfully");
        }
    }
}