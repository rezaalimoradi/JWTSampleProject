using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateProvinceCommandHandler : IRequestHandler<UpdateProvinceCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateProvinceCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProvinceCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Provinces.Find(request.ProvinceId);

            //var currentUser = _appDbContext.Users.Find(request.Id);
            //if (res.UserId != currentUser.UserId)
            //{
            //    response.Add("Error", "This Product Not Create Your User");
            //}

            if (res != null)
            {
                var product = _mapper.Map<Province>(res);
                product.ProvinceName = request.ProvinceName;
                product.ProvinceId = request.ProvinceId;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest For Province Update");
            }

        }
    }

    public class UpdateProvinceCommand : IRequest
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
