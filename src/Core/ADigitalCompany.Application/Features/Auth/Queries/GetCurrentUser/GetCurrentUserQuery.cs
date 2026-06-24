using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADigitalCompany.Application.Models.Identity;
using MediatR;

namespace ADigitalCompany.Application.Features.Auth.Queries.GetCurrentUser
{
    public record GetCurrentUserQuery() : IRequest<User>;//maybe use a dto with email and id or firstname
}