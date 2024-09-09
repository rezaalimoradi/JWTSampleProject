using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace JWTSampleProject.Core.Commands
{
    public class AddPersonCommandHandler : IRequestHandler<AddPersonCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddPersonCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddPersonCommand request, CancellationToken cancellationToken)
        {

            //var product = _mapper.Map<Product>(request);

            var obj = new Person
            {
                PersonName = request.PersonName,
                BirthDate = request.BirthDate,
                Roles = request.Roles
            };

            await _context.Persons.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }


    public class AddPersonCommand : IRequest
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Role> Roles { get; set; }
    }
}
