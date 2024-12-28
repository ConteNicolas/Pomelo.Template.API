using Microsoft.EntityFrameworkCore;
using Pomelo.Template.API.Shared.Models;

namespace Pomelo.Template.API.Shared.Extensions;

public static class EFPaginationResultExtensions
{
    public static Task<PaginatedResult<TDestination>> ToPaginatedResultAsync<TDestination>(
        this IQueryable<TDestination> queryable, int currentPage, int pageSize, CancellationToken cancellationToken)
        where TDestination : class
    {
        return PaginatedResult<TDestination>.CreateAsync(queryable.AsNoTracking(), currentPage, pageSize, cancellationToken);
    }
}