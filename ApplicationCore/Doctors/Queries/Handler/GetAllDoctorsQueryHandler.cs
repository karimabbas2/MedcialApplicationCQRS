using ApplicationCore.Departments.Queries.Queries;
using ApplicationCore.Doctors.Queries.GetlDoctorById;
using ApplicationCore.Doctors.Queries.Queries;
using ApplicationCore.Doctors.Queries.Results;
using ApplicationCore.HandleResponse;
using ApplicationCore.Interfaces;
using ApplicationDomain;
using AutoMapper;
using MediatR;

namespace ApplicationCore.Doctors.Queries
{
    public class GetAllDoctorsQueryHandler(IDoctorRepository doctorRepository, IMapper mapper) :
    IRequestHandler<GetAllDoctorsQuery, ResponseResult<List<DoctorListDto>>>,
    IRequestHandler<DoctorQuery, ResponseResult<DoctorListDto>>,
    IRequestHandler<GetAllDeptDoctorsWithSP, ResponseResult<List<DeptDoctorsWithSP>>>


    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<ResponseResult<List<DoctorListDto>>> Handle(GetAllDoctorsQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync();
            return ResponseHandler.Success(_mapper.Map<List<DoctorListDto>>(doctors));
        }

        public async Task<ResponseResult<DoctorListDto>> Handle(DoctorQuery request, CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.GetDoctorByIdAsync(request.Id) ?? throw new KeyNotFoundException();
            return ResponseHandler.Success(_mapper.Map<DoctorListDto>(doctor));
        }

        public async Task<ResponseResult<List<DeptDoctorsWithSP>>> Handle(GetAllDeptDoctorsWithSP request, CancellationToken cancellationToken)
        {
            var result = await _doctorRepository.Get_all_DeptDoctors_With_SP();
            return ResponseHandler.Success(result);
        }
    }
}