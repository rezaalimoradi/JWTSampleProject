using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class UserByIdQueryHandler : IRequestHandler<UserByIdQueryInputModel, User>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public UserByIdQueryHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        async Task<User> IRequestHandler<UserByIdQueryInputModel, User>.Handle(UserByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id, cancellationToken);

            var result = _mapper.Map<User>(user);

            return result;
        }
    }
}
