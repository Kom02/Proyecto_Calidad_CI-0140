using System.Threading.Tasks;
using EmprendeUCR_WebApplication.Domain.Core.Entities;

namespace EmprendeUCR_WebApplication.Domain.Core.Repositories
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}