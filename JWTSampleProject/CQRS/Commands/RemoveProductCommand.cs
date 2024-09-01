using AutoMapper;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace KarafariniPlans.Core.Services.Commands.GeneralData
{
    public class RemoveActivityTypeCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveActivityTypeCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var obj = _appDbContext.Products.Find(request.Id);

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
