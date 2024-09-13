using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class ReligionQueryHandler : IRequestHandler<ReligionQueryInputModel, List<ReligionDto>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public ReligionQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ReligionDto>> Handle(ReligionQueryInputModel request, CancellationToken cancellationToken)
        {
            var religion = await _context.Religions.ToListAsync();
            var res = _mapper.Map<List<ReligionDto>>(religion);
            return res;
        }
    }
}
