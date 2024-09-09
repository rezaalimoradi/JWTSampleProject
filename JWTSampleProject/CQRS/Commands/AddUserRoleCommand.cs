using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Data;

namespace JWTSampleProject.Core.Commands
{
    public class AddUserRoleCommandHandler : IRequestHandler<AddUserRoleCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddUserRoleCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {

            //var product = _mapper.Map<Product>(request);

            var obj = new UserRole
            {
                UserRoleId = request.UserRoleId,
                UserId = request.UserId,
                RoleId = request.RoleId
            };

            await _context.UserRoles.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }


    public class AddUserRoleCommand : IRequest
    {
        public int UserRoleId { get; set; }
        public int RoleId { get; set; }
        public Guid UserId { get; set; }
    }
}
