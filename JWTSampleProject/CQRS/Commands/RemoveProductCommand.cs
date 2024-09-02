using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Services.Commands.GeneralData
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveProductCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Products.Find(request.Id);


            var currentUser = _appDbContext.Users.Find(request.Id);

            if (obj == null || currentUser == null || obj.UserId != currentUser.UserId)
            {
                response.Add("Error", "This Product Not Create Your User");
            }

            if (obj != null)
            {
                _appDbContext.Products.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
    }
}
