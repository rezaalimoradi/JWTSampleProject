using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.Queries
{
    public class ReligionByIdQueryHandler : IRequestHandler<ReligionByIdQueryInputModel, Religion>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public ReligionByIdQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Religion> Handle(ReligionByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var religion = await _context.Countries.FindAsync(request.ReligionId);
            var res = _mapper.Map<Religion>(religion);
            return res;
        }
    }
}
