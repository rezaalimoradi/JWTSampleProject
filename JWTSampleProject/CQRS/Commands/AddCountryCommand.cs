using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.Core.Commands
{
    public class AddCountryCommandHandler : IRequestHandler<AddCountryCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddCountryCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddCountryCommand request, CancellationToken cancellationToken)
        {

            var country = _mapper.Map<Country>(request);

            //var obj = new Country
            //{
            //    CountryName = request.CountryName
            //};

            await _context.Countries.AddAsync(country);
            await _context.SaveChangesAsync();
        }
    }


    public class AddCountryCommand : IRequest
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
