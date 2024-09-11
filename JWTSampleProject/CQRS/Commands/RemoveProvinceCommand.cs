using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveProvinceCommandHandler : IRequestHandler<RemoveProvinceCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveProvinceCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveProvinceCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Provinces.Find(request.ProvinceId);

            //var currentUser = _appDbContext.Users.Find(request.Id);
            //if (obj.UserId != currentUser.UserId)
            //{
            //    response.Add("Error", "This User Not Create Your User");
            //}

            if (obj != null)
            {
                _appDbContext.Provinces.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveProvinceCommand : IRequest
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
