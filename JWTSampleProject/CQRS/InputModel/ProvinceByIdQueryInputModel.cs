using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ProvinceByIdQueryInputModel : IRequest<Province>
    {
        public int ProvinceId { get; set; }

    }
}
