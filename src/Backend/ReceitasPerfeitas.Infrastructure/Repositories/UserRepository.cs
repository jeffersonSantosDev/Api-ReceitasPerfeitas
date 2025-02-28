using Microsoft.EntityFrameworkCore;
using ReceitasPerfeitas.Domain.Entities;
using ReceitasPerfeitas.Domain.Repositories;
using ReceitasPerfeitas.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        readonly private ReceitasPerfeitasDbContext _dbContext;

        public UserRepository(ReceitasPerfeitasDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task Add(User user) => await _dbContext.AddAsync(user);
        public async Task ExistActiveUserWithEmail(string email) => await _dbContext.User.AnyAsync(user => user.Email.Equals(user) && user.Active);
    }
}
