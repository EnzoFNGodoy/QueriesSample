using QueriesSample.Domain.Core.Entities;
using System.Linq.Expressions;

namespace QueriesSample.Domain.Core.Repositories;

public interface IBaseRepository<T> where T : Entity<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetOneWhere(Expression<Func<T, bool>> condition);

    Task Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}