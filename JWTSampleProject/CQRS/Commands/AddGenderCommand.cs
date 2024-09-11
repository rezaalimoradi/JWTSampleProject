using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.Core.Commands
{
    public class AddGenderCommandHandler : IRequestHandler<AddGenderCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddGenderCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddGenderCommand request, CancellationToken cancellationToken)
        {

            var gender = _mapper.Map<Gender>(request);

            //var obj = new Country
            //{
            //    CountryName = request.CountryName
            //};

            await _context.Genders.AddAsync(gender);
            await _context.SaveChangesAsync();
        }
    }


    public class AddGenderCommand : IRequest
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
