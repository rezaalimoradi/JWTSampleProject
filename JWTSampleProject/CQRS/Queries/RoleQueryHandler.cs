using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class RoleQueryHandler : IRequestHandler<RoleQueryInputModel, List<Role>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public RoleQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<Role>> Handle(RoleQueryInputModel request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.ToListAsync();

            var result = _mapper.Map<List<Role>>(user);

            return result;
        }
    }
}
