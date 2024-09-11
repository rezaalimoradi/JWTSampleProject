using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class CountryQueryHandler : IRequestHandler<CountryQueryInputModel, Country>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public CountryQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Country> Handle(CountryQueryInputModel request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FirstAsync();
            var res = _mapper.Map<Country>(country);
            return res;
        }
    }
}
