using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Services.Commands.GeneralData
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveUserCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Users.Find(request.Id);

            var currentUser = _appDbContext.Users.Find(request.Id);
            if (obj.UserId != currentUser.UserId)
            {
                response.Add("Error", "This User Not Create Your User");
            }

            if (obj != null)
            {
                _appDbContext.Users.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
