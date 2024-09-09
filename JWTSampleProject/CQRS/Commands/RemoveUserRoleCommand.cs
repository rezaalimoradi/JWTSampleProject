using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveUserRoleCommandHandler : IRequestHandler<RemoveUserRoleCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveUserRoleCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveUserRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.UserRoles.Find(request.UserRoleId);

            var currentUser = _appDbContext.UserRoles.Find(request.UserRoleId);
            if (obj.UserId != currentUser.UserId)
            {
                response.Add("Error", "This UserRole Not Create Your User");
            }

            if (obj != null)
            {
                _appDbContext.UserRoles.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveUserRoleCommand : IRequest
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public Guid UserId { get; set; }

    }
}
