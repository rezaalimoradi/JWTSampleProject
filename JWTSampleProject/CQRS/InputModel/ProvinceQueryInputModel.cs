﻿using JWTSampleProject.Models;
using MediatR;

namespace JWTSampleProject.CQRS.InputModel
{
    public class ProvinceQueryInputModel : IRequest<Province>
    {
        public string ProvinceName { get; set; }

    }
}
