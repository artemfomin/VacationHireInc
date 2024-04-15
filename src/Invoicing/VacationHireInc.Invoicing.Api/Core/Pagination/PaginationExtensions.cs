namespace VacationHireInc.Invoicing.Api.Core.Pagination;

public static class PaginationExtensions
{
    public static IQueryable<TModel> ApplyPagination<TModel>(this IQueryable<TModel> sourceQuery,
        PaginationOptions paginationOptions)
    {
        if (paginationOptions?.Enabled != true)
            return sourceQuery;

        if (paginationOptions.PageSize > 0 && paginationOptions.PageNumber > 0)
            sourceQuery = sourceQuery.Skip(((int)paginationOptions.PageNumber - 1) * (int)paginationOptions.PageSize);

        if (paginationOptions.PageSize > 0)
            sourceQuery = sourceQuery.Take((int)paginationOptions.PageSize);

        return sourceQuery;
    }
}