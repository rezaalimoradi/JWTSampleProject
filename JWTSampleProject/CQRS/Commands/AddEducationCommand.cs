using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.Core.Commands
{
    public class AddEducationCommandHandler : IRequestHandler<AddEducationCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddEducationCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddEducationCommand request, CancellationToken cancellationToken)
        {

            var education = _mapper.Map<Education>(request);

            //var obj = new Education
            //{
            //    EducationName = request.EducationName
            //};

            await _context.Educations.AddAsync(education);
            await _context.SaveChangesAsync();
        }
    }


    public class AddEducationCommand : IRequest
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }
    }
}
