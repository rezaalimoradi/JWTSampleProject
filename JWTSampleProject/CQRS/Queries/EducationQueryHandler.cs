using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class EducationQueryHandler : IRequestHandler<EducationQueryInputModel, List<EducationDto>>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public EducationQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<EducationDto>> Handle(EducationQueryInputModel request, CancellationToken cancellationToken)
        {
            var educations = await _context.Educations.ToListAsync();

            var result = _mapper.Map<List<Education>, List<EducationDto>>(educations);

            return result;
        }
    }
}
