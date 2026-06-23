using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<AuthResponse>
    {
        public string RefreshToken { get; set; }
    }
}