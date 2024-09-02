using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Services.Commands.GeneralData
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Users.Find(request.Id);

            var currentUser = _appDbContext.Users.Find(request.Id);
            if (res.UserId != currentUser.UserId)
            {
                response.Add("Error", "This User Not Create Your User");
            }

            if (res != null)
            {
                var user = _mapper.Map<User>(res);
                user.IsActive = request.IsActive;
                user.Email = request.Email;
                user.PassWord = request.PassWord;
                user.Role = request.Role;
                user.Phone = request.Phone;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.BirthDate = request.BirthDate;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest");
            }

        }
    }

    public class UpdateUserCommand : IRequest
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
