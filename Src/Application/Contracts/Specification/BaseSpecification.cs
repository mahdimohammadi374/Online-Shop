using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Application.Contracts.Specification;

public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
{
    public Expression<Func<T, bool>> Condition { get; }

    public List<Expression<Func<T, object>>> Includes { get; } = new();

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDesc { get; private set; }

    public BaseSpecification()
    {
    }

    public BaseSpecification(Expression<Func<T, bool>> condition)
    {
        Condition = condition;
    }
    public void AddInclude (Expression<Func<T, object>> include)
    {
        Includes.Add(include);
    }
    public void AddOrderBY(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }
    public void AddOrderByDesc(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDesc = orderByDescExpression;
    }

}
