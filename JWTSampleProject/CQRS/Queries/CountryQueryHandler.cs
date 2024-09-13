using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class CountryQueryHandler : IRequestHandler<CountryQueryInputModel, List<CountryDto>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public CountryQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<CountryDto>> Handle(CountryQueryInputModel request, CancellationToken cancellationToken)
        {
            var countryTypes = await _context.Countries.ToListAsync();

            var result = _mapper.Map<List<Country>, List<CountryDto>>(countryTypes);

            return result;
        }
    }
}
