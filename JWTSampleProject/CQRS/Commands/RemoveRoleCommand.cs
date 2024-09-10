using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveRoleCommandHandler : IRequestHandler<RemoveRoleCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveRoleCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Roles.Find(request.RoleId);

            var currentUser = _appDbContext.Roles.Find(request.RoleId);
            if (obj.RoleId != null)
            {
                response.Add("Error", "This Role Not Create Your User");
            }

            if (obj != null)
            {
                _appDbContext.Roles.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveRoleCommand : IRequest
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Guid UserId { get; set; }

    }
}
