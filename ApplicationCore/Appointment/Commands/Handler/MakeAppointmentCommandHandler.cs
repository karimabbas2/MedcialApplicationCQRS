using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Appointment.Commands.Command;
using ApplicationCore.Appointment.Commands.Validations;
using ApplicationCore.Appointment.Queries.GetAllApointment;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Appointment.Commands
{
    public class MakeAppointmentCommandHandler(IAppointmentRepoistory appointmentRepoistory, IMapper mapper) :
    IRequestHandler<MakeAppointmentCommand, ResponseResult<object>>,
    IRequestHandler<DeleteAppointmentCommand, ResponseResult<string>>,
    IRequestHandler<UpdateAppointmentCommand, ResponseResult<object>>
    {
        private readonly IAppointmentRepoistory _appointmentRepoistory = appointmentRepoistory;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseResult<object>> Handle(MakeAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new MakeAppointmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors<object>(validationResult.Errors[0].ToString());

            var NewAppointment = _mapper.Map<ApplicationDomain.Appointment>(request);
            await _appointmentRepoistory.InsertAsync(NewAppointment);

            var appointment = await _appointmentRepoistory.GetFirstAsync(x => x.Id == NewAppointment.Id);

            return ResponseHandler.Created<object>(_mapper.Map<AppointmentsDto>(appointment));
        }

        public async Task<ResponseResult<object>> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAppointmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors<object>(validationResult.Errors[0].ToString());

            var appointment = await _appointmentRepoistory.GetAsync(request.Id);
            if (appointment is null) return ResponseHandler.NotFound<object>("appointment dose not exist");

            var MappingAppointment = _mapper.Map<ApplicationDomain.Appointment>(request);
            await _appointmentRepoistory.UpdateAsync(request.Id, MappingAppointment);

            var Updatedappointment = await _appointmentRepoistory.GetFirstAsync(x => x.Id == request.Id);
            return ResponseHandler.Success<object>(_mapper.Map<AppointmentsDto>(Updatedappointment));
        }

        async Task<ResponseResult<string>> IRequestHandler<DeleteAppointmentCommand, ResponseResult<string>>.Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
        {
            await _appointmentRepoistory.DeleteAsync(request.Id);
            return ResponseHandler.Success("Appointment Deleted Successfully");

        }
    }
}