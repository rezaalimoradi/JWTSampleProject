using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Products.Find(request.Id);

            var currentUser = _appDbContext.Users.Find(request.Id);
            if (res.UserId != currentUser.UserId)
            {
                response.Add("Error", "This Product Not Create Your User");
            }

            if (res != null)
            {
                var product = _mapper.Map<Product>(res);
                product.ProductName = request.ProductName;
                product.IsAvailable = request.IsAvailable;
                product.Email = request.Email;
                product.Phone = request.Phone;
                product.ProductDate = request.ProductDate;

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
        public bool IsAvailable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductDate { get; set; }
    }
}
