using EmprendeUCR.Domain.Core.CoreEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmprendeUCR.Domain.HomePageClientContext.Repositories
{
    public interface IDisplayProductRepository
    {
        User GetUserByEmail(string email);
    }
}