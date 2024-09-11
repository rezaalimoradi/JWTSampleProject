using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateUserRoleCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.UserRoles.Find(request.UserRoleId);

            var currentUser = _appDbContext.UserRoles.Find(request.UserRoleId);
            if (res.UserId != currentUser.UserId)
            {
                response.Add("Error", "This UserRole Not Create Your User");
            }

            if (res != null)
            {
                var user = _mapper.Map<UserRole>(res);
                user.UserRoleId = request.UserRoleId;
                user.UserId = request.UserId;
                user.RoleId = request.RoleId;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest For UserRole");
            }

        }
    }

    public class UpdateUserRoleCommand : IRequest
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
