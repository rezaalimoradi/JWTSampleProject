using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.Core.Commands
{
    public class AddMarriedCommandHandler : IRequestHandler<AddMarriedCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddMarriedCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddMarriedCommand request, CancellationToken cancellationToken)
        {

            var married = _mapper.Map<Married>(request);

            //var obj = new Married
            //{
            //    MarriedName = request.MarriedName
            //};

            await _context.Marrieds.AddAsync(married);
            await _context.SaveChangesAsync();
        }
    }


    public class AddMarriedCommand : IRequest
    {
        public int MarriedId { get; set; }
        public string MarriedName { get; set; }
    }
}
