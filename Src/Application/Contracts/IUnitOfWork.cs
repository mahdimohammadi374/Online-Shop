using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts;

public interface IUnitOfWork
{
    DbContext dbContext { get; }
    IGenericRepository<T>  Repository<T>() where T : BaseEntity;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
