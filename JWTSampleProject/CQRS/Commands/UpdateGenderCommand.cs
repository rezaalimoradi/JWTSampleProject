using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;
using System.Net;

namespace JWTSampleProject.Core.Commands
{
    public class UpdateGenderCommandHandler : IRequestHandler<UpdateGenderCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UpdateGenderCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(UpdateGenderCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();
            var res = _appDbContext.Genders.Find(request.GenderId);

            var currentGender = _appDbContext.Genders.Find(request.GenderId);
            if (res.GenderId != currentGender.GenderId)
            {
                response.Add("Error", "This Gender Not Create Your User");
            }

            if (res != null)
            {
                var Gender = _mapper.Map<Gender>(res);
                Gender.GenderName = request.GenderName;


                await _appDbContext.SaveChangesAsync();
            }
            else
            {
                response.Add("Error", "BadRequest For Gender Update");
            }

        }
    }

    public class UpdateGenderCommand : IRequest
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
