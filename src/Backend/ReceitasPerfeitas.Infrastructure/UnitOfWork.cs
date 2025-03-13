using ReceitasPerfeitas.Domain.Repositories;
using ReceitasPerfeitas.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceitasPerfeitas.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        readonly private ReceitasPerfeitasDbContext _dbContext;

        public UnitOfWork(ReceitasPerfeitasDbContext dbContext) => _dbContext = dbContext;
        public Task Commit() => _dbContext.SaveChangesAsync();
    }
}
