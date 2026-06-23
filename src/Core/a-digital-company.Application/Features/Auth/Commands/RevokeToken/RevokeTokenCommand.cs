using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Commands.RevokeToken
{
    public class RevokeTokenCommand : IRequest<Unit>
    {
        public string RefreshToken { get; set; }
    }
}