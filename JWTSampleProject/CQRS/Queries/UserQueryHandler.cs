using AutoMapper;
using Infrastructure.Dto;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class UserQueryHandler : IRequestHandler<UserQueryInputModel, List<UserDto>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public UserQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(UserQueryInputModel request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.ToListAsync();

            var result = _mapper.Map<List<UserDto>>(user);

            return result;
        }
    }
}
