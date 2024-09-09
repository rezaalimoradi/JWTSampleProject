using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdatePersonCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Persons.Find(request.PersonId);

            if (res != null)
            {
                var product = _mapper.Map<Person>(res);
                product.PersonId = request.PersonId;
                product.PersonName = request.PersonName;
                product.BirthDate = request.BirthDate;
                product.Roles = request.Roles;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest");
            }

        }
    }

    public class UpdatePersonCommand : IRequest
    {
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public DateTime BirthDate { get; set; }
        public List<Role> Roles { get; set; }
    }
}
