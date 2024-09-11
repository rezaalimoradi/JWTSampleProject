using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveCountryCommandHandler : IRequestHandler<RemoveCountryCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveCountryCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Countries.Find(request.CountryId);

            //var currentUser = _appDbContext.Users.Find(request.Id);
            //if (obj.UserId != currentUser.UserId)
            //{
            //    response.Add("Error", "This User Not Create Your User");
            //}

            if (obj != null)
            {
                _appDbContext.Countries.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveCountryCommand : IRequest
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
