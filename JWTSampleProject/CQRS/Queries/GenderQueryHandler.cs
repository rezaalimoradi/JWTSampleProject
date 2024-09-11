using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class GenderQueryHandler : IRequestHandler<GenderQueryInputModel, Gender>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public GenderQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Gender> Handle(GenderQueryInputModel request, CancellationToken cancellationToken)
        {
            var gender = await _context.Genders.FirstAsync();
            var res = _mapper.Map<Gender>(gender);
            return res;
        }
    }
}
