﻿using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Application.Contracts.Specification;

public class SpecificationEvaluator<T> where T : BaseEntity 
{
    public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
    {
           var query = inputQuery.AsQueryable();
        if(specification.Condition != null)
            query = query.Where(specification.Condition);

        if (specification.Includes.Any())
            query = specification.Includes.Aggregate(query, (current, value) => current.Include(value));

        if (specification.OrderBy != null)
            query = query.OrderBy(specification.OrderBy);

        if (specification.OrderByDesc != null)
            query = query.OrderByDescending(specification.OrderByDesc);

        return query;
        
    }
}
