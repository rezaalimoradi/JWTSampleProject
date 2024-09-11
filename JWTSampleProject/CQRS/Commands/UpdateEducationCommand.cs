using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateEducationCommandHandler : IRequestHandler<UpdateEducationCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateEducationCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateEducationCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Educations.Find(request.EducationId);

            //var currentUser = _appDbContext.Users.Find(request.Id);
            //if (res.UserId != currentUser.UserId)
            //{
            //    response.Add("Error", "This Product Not Create Your User");
            //}

            if (res != null)
            {
                var education = _mapper.Map<Education>(res);
                //education.EducationName = request.EducationName;
                //education.EducationId = request.EducationId;

                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest For Education Update");
            }

        }
    }

    public class UpdateEducationCommand : IRequest
    {
        public int EducationId { get; set; }
        public string EducationName { get; set; }
    }
}
