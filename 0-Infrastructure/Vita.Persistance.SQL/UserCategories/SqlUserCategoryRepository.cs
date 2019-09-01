﻿using System;
using System.Collections.Generic;
using Vita.Domain.UsersCategories;

namespace Vita.Persistance.Sql.UserCategories
{
    public class SqlUserCategoryRepository : IUserCategoryRepository
    {
        private VitaDbContext VitaDbContext { get; set; }

        public SqlUserCategoryRepository(VitaDbContext vitaDbContext)
        {
            VitaDbContext = vitaDbContext;
        }
        
        public IEnumerable<UserCategory> GetAllUsersCategories()
        {
            return VitaDbContext.UsersCategories;
        }

        public void CreateUserCategory(UserCategory userCategory)
        {
            VitaDbContext.UsersCategories.Add(userCategory);
        }

        public void Save()
        {
            VitaDbContext.SaveChanges();
        }

    }
}
