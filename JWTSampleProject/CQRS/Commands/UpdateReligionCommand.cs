using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateReligionCommandHandler : IRequestHandler<UpdateReligionCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateReligionCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateReligionCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Countries.Find(request.ReligionId);

            //var currentUser = _appDbContext.Users.Find(request.Id);
            //if (res.UserId != currentUser.UserId)
            //{
            //    response.Add("Error", "This Product Not Create Your User");
            //}

            if (res != null)
            {
                var product = _mapper.Map<Religion>(res);
                product.ReligionName = request.ReligionName;
                product.ReligionId = request.ReligionId;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest For Religion Update");
            }

        }
    }

    public class UpdateReligionCommand : IRequest
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
    }
}
