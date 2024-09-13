using Infrastructure.Dto;
using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserQueryInputModel : IRequest<List<UserDto>>
    {
        

    }
}
