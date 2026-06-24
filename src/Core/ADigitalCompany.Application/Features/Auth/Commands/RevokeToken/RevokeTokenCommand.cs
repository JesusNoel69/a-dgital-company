using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Auth.Commands.RevokeToken
{
    public class RevokeTokenCommand : IRequest<Unit>
    {
        public string RefreshToken { get; set; }
    }
}