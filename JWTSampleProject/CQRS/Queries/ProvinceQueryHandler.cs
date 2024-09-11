using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class ProvinceQueryHandler : IRequestHandler<ProvinceQueryInputModel, Province>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public ProvinceQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Province> Handle(ProvinceQueryInputModel request, CancellationToken cancellationToken)
        {
            var province = await _context.Provinces.FirstAsync();
            var res = _mapper.Map<Province>(province);
            return res;
        }
    }
}
