using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveReligionCommandHandler : IRequestHandler<RemoveReligionCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveReligionCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveReligionCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Religions.Find(request.ReligionId);

            var currentReligion = _appDbContext.Religions.Find(request.ReligionId);
            if (obj.ReligionId != currentReligion.ReligionId)
            {
                response.Add("Error", "This Religion Not Create Your User For Remove");
            }

            if (obj != null)
            {
                _appDbContext.Religions.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveReligionCommand : IRequest
    {
        public int ReligionId { get; set; }
    }
}
