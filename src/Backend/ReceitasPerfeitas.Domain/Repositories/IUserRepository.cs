using ReceitasPerfeitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Domain.Repositories
{
    public interface IUserRepository
    {

        Task Add(User user);
        Task<bool> ExistActiveUserWithEmail(string email);
    }
}
