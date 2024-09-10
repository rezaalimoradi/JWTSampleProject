using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemovePersonCommandHandler : IRequestHandler<RemovePersonCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemovePersonCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemovePersonCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Persons.Find(request.PersonId);

            if (obj != null)
            {
                _appDbContext.Persons.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemovePersonCommand : IRequest
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
