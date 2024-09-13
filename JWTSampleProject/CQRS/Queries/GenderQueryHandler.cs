using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class GenderQueryHandler : IRequestHandler<GenderQueryInputModel, List<GenderDto>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public GenderQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<GenderDto>> Handle(GenderQueryInputModel request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.ToListAsync();
            var res = _mapper.Map<List<GenderDto>>(gender);
            return res;
        }
    }
}
