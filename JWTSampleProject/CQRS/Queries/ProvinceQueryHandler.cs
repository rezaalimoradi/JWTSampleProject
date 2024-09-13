using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProvinceQueryHandler : IRequestHandler<ProvinceQueryInputModel, List<ProvinceDto>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public ProvinceQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ProvinceDto>> Handle(ProvinceQueryInputModel request, CancellationToken cancellationToken)
        {
            var province = await _context.Provinces.ToListAsync();

            var result = _mapper.Map<List<ProvinceDto>>(province);

            return result;
        }
    }
}
