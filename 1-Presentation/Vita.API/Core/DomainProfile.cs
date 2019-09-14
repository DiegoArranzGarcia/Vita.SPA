﻿using AutoMapper;
using Vita.API.Categories;
using Vita.API.Users.Dtos;
using Vita.Domain.Models;

namespace Vita.API.Core
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<User, UserDto>();
        }

    }
}
