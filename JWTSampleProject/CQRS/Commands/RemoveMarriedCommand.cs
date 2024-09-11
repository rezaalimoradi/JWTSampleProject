using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveMarriedCommandHandler : IRequestHandler<RemoveMarriedCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveMarriedCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveMarriedCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Marrieds.Find(request.MarriedId);

            var currentMarried = _appDbContext.Marrieds.Find(request.MarriedId);
            if (obj.MarriedId != currentMarried.MarriedId)
            {
                response.Add("Error", "This Married Not Create Your User");
            }

            if (obj != null)
            {
                _appDbContext.Marrieds.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveMarriedCommand : IRequest
    {
        public int MarriedId { get; set; }
        public string MarriedName { get; set; }
    }
}
