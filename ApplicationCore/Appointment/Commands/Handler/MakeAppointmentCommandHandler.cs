using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Appointment.Commands.AddAppointment;
using ApplicationCore.Exceptions;
using ApplicationCore.HandleResponse;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Appointment.Commands
{
    public class MakeAppointmentCommandHandler(IAppointmentRepoistory appointmentRepoistory, IMapper mapper) :
    IRequestHandler<MakeAppointmentCommand, ResponseResult<string>>
    {
        private readonly IAppointmentRepoistory _appointmentRepoistory = appointmentRepoistory;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseResult<string>> Handle(MakeAppointmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new MakeAppointmentCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return ResponseHandler.ValidtionErrors(validationResult.Errors[0].ToString());

            var NewAppointment = _mapper.Map<ApplicationDomain.Appointment>(request);

            if (await _appointmentRepoistory.GetAsync(NewAppointment.Id) is not null) return ResponseHandler.Conflicted<string>("This Appointment is Exsit");
            await _appointmentRepoistory.InsertAsync(NewAppointment);
            return ResponseHandler.Created("New Apponintmet Resirved Successfully");
        }
    }
}