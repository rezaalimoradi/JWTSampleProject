using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class MarriedQueryHandler : IRequestHandler<MarriedQueryInputModel, Married>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public MarriedQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Married> Handle(MarriedQueryInputModel request, CancellationToken cancellationToken)
        {
            var married = await _context.Marrieds.FirstAsync();
            var res = _mapper.Map<Married>(married);
            return res;
        }
    }
}
