using EmprendeUCR.Domain.Core.CoreEntities;
using EmprendeUCR.Domain.Core.Repositories;
using EmprendeUCR.Domain.HomePageClientContext.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Infrastructure.HomePageClientContext.Repositories
{
    public class DisplayProductRepository : IDisplayProductRepository
    {
        private readonly DisplayProductDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public DisplayProductRepository(DisplayProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByEmail(string email)
        {
            return _dbContext.User.FirstOrDefault(user => user.Email.Equals(email));

        }
    }
}