using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;

namespace KarafariniPlans.Core.Services.Commands.GeneralData
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddProductCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {

            //var product = _mapper.Map<Product>(request);

            var obj = new Product
            {
                Email = request.Email,
                Id = request.Id,
                IsAvailable = request.IsAvailable,
                Phone = request.Phone,
                ProductDate = request.ProductDate,
                ProductName = request.ProductName
            };

            await _context.Products.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }


    public class AddProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool IsAvailable { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProductName { get; set; }
        public DateTime ProductDate { get; set; }
    }
}
