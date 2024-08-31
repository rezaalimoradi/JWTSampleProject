﻿using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class UserByIdQueryInputModel : IRequest<User>
    {

        public Guid Id { get; set; }
    }
}
