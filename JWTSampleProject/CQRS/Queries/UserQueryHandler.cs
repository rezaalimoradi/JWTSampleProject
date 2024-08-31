using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class UserQueryHandler : IRequestHandler<UserQueryInputModel, User>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UserQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> Handle(UserQueryInputModel request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstAsync();
            var res = _mapper.Map<User>(user);
            return res;
        }
    }
}
