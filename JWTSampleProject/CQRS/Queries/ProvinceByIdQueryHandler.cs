using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProvinceByIdQueryHandler : IRequestHandler<ProvinceByIdQueryInputModel, Province>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public ProvinceByIdQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Province> Handle(ProvinceByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var province = await _context.Provinces.FindAsync(request.ProvinceId);
            var res = _mapper.Map<Province>(province);
            return res;
        }
    }
}
