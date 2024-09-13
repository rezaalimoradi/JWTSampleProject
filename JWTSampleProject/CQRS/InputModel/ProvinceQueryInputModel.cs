using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ProvinceQueryInputModel : IRequest<List<ProvinceDto>>
    {
    }
}
