using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using a_digital_company.Application.Models.Identity;
using MediatR;

namespace a_digital_company.Application.Features.Auth.Queries.GetCurrentUser
{
    public record GetCurrentUserQuery() : IRequest<User>;//maybe use a dto with email and id or firstname
}