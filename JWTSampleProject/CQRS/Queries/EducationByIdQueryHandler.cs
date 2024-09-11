using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.Queries
{
    public class EducationByIdQueryHandler : IRequestHandler<EducationByIdQueryInputModel, Education>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public EducationByIdQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Education> Handle(EducationByIdQueryInputModel request, CancellationToken cancellationToken)
        {
            var education = await _context.Educations.FindAsync(request.EducationId);
            var res = _mapper.Map<Education>(education);
            return res;
        }
    }
}
