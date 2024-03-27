using ApplicationCore.Interfaces;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Doctors.Queries
{
    public class GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository, IMapper mapper) : IRequestHandler<GetAllDoctorsQuery, List<DoctorListDto>>
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<List<DoctorListDto>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return _mapper.Map<List<DoctorListDto>>(doctors);
        }
    }
}