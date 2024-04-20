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
    public class AddDoctorCommandHandler(IDoctorRepository doctorRepository,
    IEmail email, IMapper mapper) :
     IRequestHandler<AddDoctorCommand, ResponseResult<object>>,
     IRequestHandler<DeleteDoctorCommand, ResponseResult<string>>,
     IRequestHandler<UpdateDoctorCommand, ResponseResult<object>>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IEmail _email = email;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseResult<object>> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddDoctorCommandValidation();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors<object>(validationResult.Errors[0].ToString());

            var newDoctor = _mapper.Map<Doctor>(request);
            await _doctorRepository.InsertAsync(newDoctor);

            var doctor = await _doctorRepository.GetFirstAsync(x => x.Id == newDoctor.Id);

            // await _email.SendEmailAsync(request.Email, "Test", $"Welcome {request.Name} , this is Test");
            return ResponseHandler.Created<object>(_mapper.Map<DoctorListDto>(doctor));
        }

        public async Task<ResponseResult<string>> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
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

            var MappingDoctor = _mapper.Map<Doctor>(request);
            await _doctorRepository.UpdateAsync(request.Id, MappingDoctor);

            var UpdatedDoctor = await _doctorRepository.GetFirstAsync(x => x.Id == request.Id);
            return ResponseHandler.Success<object>(_mapper.Map<DoctorListDto>(UpdatedDoctor));

        }
    }
}