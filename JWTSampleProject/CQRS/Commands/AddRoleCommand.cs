using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Data;

namespace JWTSampleProject.Core.Commands
{
    public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddRoleCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {

            //var product = _mapper.Map<Product>(request);

            var obj = new Role
            {
                RoleName = request.RoleName
            };

            await _context.Roles.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }


    public class AddRoleCommand : IRequest
    {
        public string RoleName { get; set; }
    }
}
