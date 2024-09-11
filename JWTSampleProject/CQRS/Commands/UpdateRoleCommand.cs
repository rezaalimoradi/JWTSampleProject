using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Users.Find(request.RoleId);

            var currentUser = _appDbContext.Roles.Find(request.RoleId);
            if (res.UserId != null)
            {
                response.Add("Error", "This Role Not Create Your User");
            }

            if (res != null)
            {
                var role = _mapper.Map<Role>(res);
                role.RoleName = request.RoleName;
                role.UserId = request.UserId;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequestForRole");
            }

        }
    }

    public class UpdateRoleCommand : IRequest
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid UserId { get; set; }
    }
}
