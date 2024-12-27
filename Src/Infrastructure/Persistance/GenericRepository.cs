using Application.Contracts;
using Application.Contracts.Specification;
using Domain.Entities.Base;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistance;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly DataBaseContext _context;
    private DbSet<T> dbSet; 
    public GenericRepository(DataBaseContext context)
    {
        _context = context;
        dbSet = _context.Set<T>();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await dbSet.AddAsync(entity, cancellationToken);
        return entity;
    }

    public async Task<bool> AnyAsync(Expression<Func<T,bool>> expression)
    {
        return await dbSet.AnyAsync(expression);
    }

    public async Task<int> CountSpecAsync(ISpecification<T> spec, CancellationToken cancellationToken)
    {
        return await ApplySpecification(spec).CountAsync(cancellationToken);
    }

    public async void DeleteAsync(long id)
    {
       T entity =await dbSet.FindAsync(id);
        if (entity == null)
        {
            entity.IsDeleted = true;
        }
    }

    public List<T> GetAll(CancellationToken cancellationToken)
    {
        return dbSet.ToList();
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
        var result = await dbSet.ToListAsync();
        return result;

        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<T> GetAsync(long id, CancellationToken cancellationToken)
    {
        return await dbSet.FindAsync(id, cancellationToken);
    }

    public async Task<T> GetEntityWithSpec(ISpecification<T> spec, CancellationToken cancellationToken)
    {
        return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken)
    {
        
        return await ApplySpecification(spec).ToListAsync(cancellationToken);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        T model = await dbSet.FindAsync(entity.Id);
        if (model == null)
        {
            model = entity;
        }
        return entity;
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> spec)
    {
        var q = SpecificationEvaluator<T>.GetQuery(dbSet.AsQueryable(), spec);
        return SpecificationEvaluator<T>.GetQuery(dbSet.AsQueryable(), spec);
    }
}
