using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JWTSampleProject.CQRS.Queries
{
    public class EducationQueryHandler : IRequestHandler<EducationQueryInputModel, Education>
    {
        private readonly ISampleDbContext _context;
        private readonly IMapper _mapper;

        public EducationQueryHandler(ISampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Education> Handle(EducationQueryInputModel request, CancellationToken cancellationToken)
        {
            var education = await _context.Educations.FirstAsync();
            var res = _mapper.Map<Education>(education);
            return res;
        }
    }
}
