﻿using Domain.Entities.Base;
using System.Linq.Expressions;

namespace Application.Contracts.Specification;

public interface ISpecification<T> where T : BaseEntity
{
    Expression<Func<T, bool>> Condition { get; }
    List<Expression<Func<T,object>>> Includes { get; }
    Expression<Func<T,object>> OrderBy { get; }
    Expression<Func<T,object>> OrderByDesc { get; }
    public int Take { get; set; }
    public int Skip { get; set; }
    public bool IsPaginEnabled { get; }
}
