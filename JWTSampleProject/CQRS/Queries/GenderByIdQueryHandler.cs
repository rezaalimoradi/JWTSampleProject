using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.Queries
{
    public class GenderByIdQueryHandler : IRequestHandler<GenderByIdQueryInputModel, Gender>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public GenderByIdQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Gender> Handle(GenderByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.FindAsync(request.GenderId);
            var res = _mapper.Map<Gender>(gender);
            return res;
        }
    }
}
