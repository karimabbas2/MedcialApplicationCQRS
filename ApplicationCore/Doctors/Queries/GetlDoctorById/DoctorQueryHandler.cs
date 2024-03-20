using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.interfaces;
using ApplicationCore.Interfaces;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Doctors.Queries.GetlDoctorById
{
    public class DoctorQueryHandler(IDoctorRepository doctorRepository, IMapper mapper) : IRequestHandler<DoctorQuery, DoctoDto>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IMapper _mapper = mapper;
        public async Task<DoctoDto> Handle(DoctorQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(request.Id);
            return _mapper.Map<DoctoDto>(doctor);

        }
    }
}