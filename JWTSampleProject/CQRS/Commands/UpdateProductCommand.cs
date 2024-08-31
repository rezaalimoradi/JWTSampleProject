using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace KarafariniPlans.Core.Services.Commands.GeneralData
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Products.Find(request.Id);
            if (res != null)
            {
                var product = _mapper.Map<Product>(res);
                product.ProductName = request.productName;
                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest");
            }

        }
    }

    public class UpdateProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public string productName { get; set; }
    }
}
