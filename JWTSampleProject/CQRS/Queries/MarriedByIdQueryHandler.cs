using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.Queries
{
    public class MarriedByIdQueryHandler : IRequestHandler<MarriedByIdQueryInputModel, Married>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public MarriedByIdQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Married> Handle(MarriedByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var married = await _context.Marrieds.FindAsync(request.MarriedId);
            var res = _mapper.Map<Married>(married);
            return res;
        }
    }
}
