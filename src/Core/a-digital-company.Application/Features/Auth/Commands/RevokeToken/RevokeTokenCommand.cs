using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a-digital-company.Application.Models.Identity;
using MediatR;

namespace a-digital-company.Application.Features.Auth.Commands.RevokeToken
{
    public class RevokeTokenCommand : IRequest<Unit>
    {
        public string RefreshToken { get; set; }
    }
}