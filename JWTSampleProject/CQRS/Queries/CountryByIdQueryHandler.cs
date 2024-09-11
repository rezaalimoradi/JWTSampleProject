using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.Queries
{
    public class CountryByIdQueryHandler : IRequestHandler<CountryByIdQueryInputModel, Country>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public CountryByIdQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Country> Handle(CountryByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FindAsync(request.CountryId);
            var res = _mapper.Map<Country>(country);
            return res;
        }
    }
}
