using Application.Contracts;
using Domain.Entities.Base;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly DataBaseContext _dataBaseContext;

    public UnitOfWork(DataBaseContext dataBaseContext)
    {
        _dataBaseContext = dataBaseContext;
    }

    public DbContext dbContext => _dataBaseContext;

    public IGenericRepository<T> Repository<T>() where T : BaseEntity
        => new GenericRepository<T>(_dataBaseContext);
    

    public int SaveChanges() =>_dataBaseContext.SaveChanges();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        =>await _dataBaseContext.SaveChangesAsync(cancellationToken);
}
