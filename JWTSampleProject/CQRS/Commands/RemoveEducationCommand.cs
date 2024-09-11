using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveEducationCommandHandler : IRequestHandler<RemoveEducationCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveEducationCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveEducationCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Educations.Find(request.EducationId);

            //var currentUser = _appDbContext.Users.Find(request.Id);
            //if (obj.UserId != currentUser.UserId)
            //{
            //    response.Add("Error", "This User Not Create Your User");
            //}

            if (obj != null)
            {
                _appDbContext.Educations.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveEducationCommand : IRequest
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }
    }
}
