using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Data;

namespace JWTSampleProject.Core.Commands
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddUserCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            //var product = _mapper.Map<Product>(request);

            var obj = new User
            {
                Email = request.Email,
                UserId = request.Id,
                IsActive = request.IsActive,
                Phone = request.Phone,
                PassWord = request.PassWord,
                Role = request.Role,
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate
            };

            await _context.Users.AddAsync(obj);
            await _context.SaveChangesAsync();
        }
    }


    public class AddUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
