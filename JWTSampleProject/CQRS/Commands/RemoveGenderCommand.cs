using AutoMapper;
using Azure;
using JWTSampleProject.Context;
using MediatR;
using System.Net;
using System.Web.Http;

namespace JWTSampleProject.Core.Commands
{
    public class RemoveGenderCommandHandler : IRequestHandler<RemoveGenderCommand>
    {
        private readonly ISampleDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RemoveGenderCommandHandler(ISampleDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task Handle(RemoveGenderCommand request, CancellationToken cancellationToken)
        {
            var response = new Dictionary<string, string>();

            var obj = _appDbContext.Genders.Find(request.GenderId);

            var currentGender = _appDbContext.Genders.Find(request.GenderId);
            if (obj.GenderId != currentGender.GenderId)
            {
                response.Add("Error", "This Gender Not Create Your User For Remove");
            }

            if (obj != null)
            {
                _appDbContext.Genders.Remove(obj);
                await _appDbContext.SaveChangesAsync();

            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }
    }

    public class RemoveGenderCommand : IRequest
    {
        public int GenderId { get; set; }
        public string GenderName { get; set; }
    }
}
