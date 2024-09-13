using AutoMapper;
using JWTSampleProject.Context;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.Core.Commands
{
    public class AddProvinceCommandHandler : IRequestHandler<AddProvinceCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISampleDbContext _context;

        public AddProvinceCommandHandler(IMapper mapper, ISampleDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task Handle(AddProvinceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var province = _mapper.Map<Province>(request);

                //var obj = new Province
                //{
                //    ProvinceName = request.ProvinceName
                //};

                await _context.Provinces.AddAsync(province);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }


    public class AddProvinceCommand : IRequest
    {
        public int ProvinceId { get; set; }
        public string ProvinceName { get; set; }
    }
}
