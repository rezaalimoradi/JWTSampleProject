using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class UserRoleQueryHandler : IRequestHandler<UserRoleQueryInputModel, List<UserRole>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public UserRoleQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserRole>> Handle(UserRoleQueryInputModel request, CancellationToken cancellationToken)
        {
            var user = await _context.UserRoles.ToListAsync();

            var result = _mapper.Map<List<UserRole>>(user);

            return result;
        }
    }
}
