using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateMarriedCommandHandler : IRequestHandler<UpdateMarriedCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateMarriedCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateMarriedCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Marrieds.Find(request.MarriedId);

            var currentMarried = _appDbContext.Marrieds.Find(request.MarriedId);
            if (res.MarriedId != currentMarried.MarriedId)
            {
                response.Add("Error", "This Married Not Create Your User");
            }

            if (res != null)
            {
                var Married = _mapper.Map<Married>(res);
                Married.MarriedName = request.MarriedName;


                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest For Married Update");
            }

        }
    }

    public class UpdateMarriedCommand : IRequest
    {
        public int MarriedId { get; set; }
        public string MarriedName { get; set; }
    }
}
