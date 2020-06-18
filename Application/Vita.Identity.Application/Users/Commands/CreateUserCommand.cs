﻿using MediatR;
using System;

namespace Vita.Identity.Application.Users.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName {get; set;}
    }
}
