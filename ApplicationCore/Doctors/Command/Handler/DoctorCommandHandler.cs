using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Doctors.Command.Commands;
using ApplicationCore.Doctors.Command.Validations;
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
    public class AddDoctorCommandHandler(IDoctorRepository doctorRepository, IDepartmentRepository departmentRepository,
    IEmail email, IMapper mapper) :
     IRequestHandler<AddDoctorCommand, ResponseResult<object>>,
     IRequestHandler<DeleteDoctorCommand, ResponseResult<string>>,
     IRequestHandler<UpdateDoctorCommand, ResponseResult<object>>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
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

            var dept = await _departmentRepository.GetFirstAsync(x => x.Id == request.DepartmentID);
            if (dept is not null)
                newDoctor.Department = dept;

            // await _email.SendEmailAsync(request.Email, "Test", $"Welcome {request.Name} , this is Test");
            return ResponseHandler.Created<object>(_mapper.Map<DoctorListDto>(newDoctor));
        }

        public async Task<ResponseResult<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            // if (await _doctorRepository.GetAsync(request.Id) is null) return ResponseHandler.NotFound<string>("No Department with this Id");
            await _doctorRepository.DeleteAsync(request.Id);
            return ResponseHandler.Success("Doctor Deleted Successfully");
        }

        public async Task<ResponseResult<object>> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDoctorCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors<object>(validationResult.Errors[0].ToString());

            var doctor = await _doctorRepository.GetAsync(request.Id);
            if (doctor is null) return ResponseHandler.NotFound<object>("this Doctor dose not exist");

            var UpdatedDoctor = _mapper.Map<Doctor>(request);

            await _doctorRepository.UpdateAsync(request.Id, UpdatedDoctor);

            var dept = await _departmentRepository.GetFirstAsync(x => x.Id == request.DepartmentID);
            if (dept is not null)
                UpdatedDoctor.Department = dept;

            return ResponseHandler.Success<object>(_mapper.Map<DoctorListDto>(UpdatedDoctor));

        }
    }
}