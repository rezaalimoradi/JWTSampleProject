using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateCountryCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Countries.Find(request.CountryId);

            //var currentUser = _appDbContext.Users.Find(request.Id);
            //if (res.UserId != currentUser.UserId)
            //{
            //    response.Add("Error", "This Product Not Create Your User");
            //}

            if (res != null)
            {
                var product = _mapper.Map<Country>(res);
                product.CountryName = request.CountryName;
                product.CountryId = request.CountryId;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest For Country Update");
            }

        }
    }

    public class UpdateCountryCommand : IRequest
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
