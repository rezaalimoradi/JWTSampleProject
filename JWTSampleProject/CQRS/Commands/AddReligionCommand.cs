using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.Core.Commands
{
    public class AddReligionCommandHandler : IRequestHandler<AddReligionCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddReligionCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddReligionCommand request, CancellationToken cancellationToken)
        {

            var religion = _mapper.Map<Religion>(request);

            //var obj = new Religion
            //{
            //    ReligionName = request.ReligionName
            //};

            await _context.Religions.AddAsync(religion);
            await _context.SaveChangesAsync();
        }
    }


    public class AddReligionCommand : IRequest
    {
        public int ReligionId { get; set; }
        public string ReligionName { get; set; }
    }
}
