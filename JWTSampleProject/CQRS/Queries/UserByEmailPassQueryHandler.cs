using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class UserByEmailPassQueryHandler : IRequestHandler<UserByEmailPassQueryInputModel, User>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public UserByEmailPassQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<User> IRequestHandler<UserByEmailPassQueryInputModel, User>.Handle(UserByEmailPassQueryInputModel request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Email, cancellationToken);

            var result = _mapper.Map<User>(user);

            return result;
        }
    }
}
