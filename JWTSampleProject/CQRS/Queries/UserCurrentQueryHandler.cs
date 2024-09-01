using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class UserCurrentQueryHandler : IRequestHandler<UserCurrentQueryInputModel, User>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UserCurrentQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<User> Handle(UserCurrentQueryInputModel request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync();

            var result = _mapper.Map<User>(user);

            return result;
        }
    }
}
