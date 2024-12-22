using System.Linq.Expressions;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using PTSL.GENERIC.Common.Entity.Beneficiary;
using PTSL.GENERIC.Common.Model.EntityViewModels;
using PTSL.GENERIC.Common.Entity;

namespace PTSL.GENERIC.Common.Helper;

public static class EntityFrameworkExtensions
{
    public static IQueryable<T> WhereIf<T>(
        this IQueryable<T> query, bool condition, Expression<Func<T, bool>> predicate)
    {
        return condition ? query.Where(predicate) : query;
    }

    public static IQueryable<T> FilterByLocation<T>(
        this IQueryable<T> query, ForestCivilLocationFilter filter)
        where T : class, IHasForestLocation
    {
        return query
            .WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId)
            .WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId)
            .WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId)
            .WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId)
            .WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId)

            .WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId)
            .WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId)
            .WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId)
            .WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);
    }

    public static IQueryable<T> FilterSurvey<T>(
        this IQueryable<T> query, ForestCivilLocationFilter filter) where T : Survey
    {
        return query
            .WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId)
            .WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId)
            .WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId)
            .WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId)
            .WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId)

            .WhereIf(filter.HasDivisionId, x => x.PresentDivisionId == filter.DivisionId)
            .WhereIf(filter.HasDistrictId, x => x.PresentDistrictId == filter.DistrictId)
            .WhereIf(filter.HasUpazillaId, x => x.PresentUpazillaId == filter.UpazillaId)
            .WhereIf(filter.HasUnionId, x => x.PresentUnionNewId == filter.UnionId);
    }

    public static IQueryable<T> FilterSurveyLocationGeneric<T, TKey>(
    this IQueryable<T> query, ForestCivilLocationFilter filter, Func<T, TKey> _)
        where T : class, IHasSurvey
    {
        return query
            .WhereIf(filter.HasForestCircleId, x => x.Survey!.ForestCircleId == filter.ForestCircleId)
            .WhereIf(filter.HasForestDivisionId, x => x.Survey!.ForestDivisionId == filter.ForestDivisionId)
            .WhereIf(filter.HasForestRangeId, x => x.Survey!.ForestRangeId == filter.ForestRangeId)
            .WhereIf(filter.HasForestBeatId, x => x.Survey!.ForestBeatId == filter.ForestBeatId)
            .WhereIf(filter.HasForestFcvVcfId, x => x.Survey!.ForestFcvVcfId == filter.ForestFcvVcfId)
            .WhereIf(filter.HasDivisionId, x => x.Survey!.PresentDivisionId == filter.DivisionId)
            .WhereIf(filter.HasDistrictId, x => x.Survey!.PresentDistrictId == filter.DistrictId)
            .WhereIf(filter.HasUpazillaId, x => x.Survey!.PresentUpazillaId == filter.UpazillaId)
            .WhereIf(filter.HasUnionId, x => x.Survey!.PresentUnionNewId == filter.UnionId);
    }

    public static IQueryable<T> FilterUser<T>(
        this IQueryable<T> query, ForestCivilLocationFilter filter) where T : User
    {
        return query
            .WhereIf(filter.HasForestCircleId, x => x.ForestCircleId == filter.ForestCircleId)
            .WhereIf(filter.HasForestDivisionId, x => x.ForestDivisionId == filter.ForestDivisionId)
            .WhereIf(filter.HasForestRangeId, x => x.ForestRangeId == filter.ForestRangeId)
            .WhereIf(filter.HasForestBeatId, x => x.ForestBeatId == filter.ForestBeatId)
            .WhereIf(filter.HasForestFcvVcfId, x => x.ForestFcvVcfId == filter.ForestFcvVcfId)

            .WhereIf(filter.HasDivisionId, x => x.DivisionId == filter.DivisionId)
            .WhereIf(filter.HasDistrictId, x => x.DistrictId == filter.DistrictId)
            .WhereIf(filter.HasUpazillaId, x => x.UpazillaId == filter.UpazillaId)
            .WhereIf(filter.HasUnionId, x => x.UnionId == filter.UnionId);
    }

    public static IQueryable<TEntity> IncludeIf<TEntity, TProperty>(this IQueryable<TEntity> query, bool condition, Expression<Func<TEntity, TProperty>> navigationProperty) where TEntity : class
    {
        return condition ? query.Include(navigationProperty) : query;
    }
}
