using System.Threading.Tasks;
using EmprendeUCR.Domain.Core.Entities;

namespace EmprendeUCR.Domain.Core.Repositories
{
    public interface IRepository<TAggregateRoot> where TAggregateRoot : AggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
