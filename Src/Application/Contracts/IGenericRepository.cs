using Application.Contracts.Specification;
using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Application.Contracts;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T> GetAsync(long Id, CancellationToken cancellationToken);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    List<T> GetAll(CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity);
    void DeleteAsync(long id);
    Task<bool> AnyAsync(Expression<Func<T,bool>> expression);
    Task<T> GetEntityWithSpec(ISpecification<T> spec, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken);
}
