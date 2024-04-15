using VacationHireInc.Rental.Core.Application.Core.MediatR.Types;

namespace VacationHireInc.Rental.Core.Application.Core.Pagination;

public interface IPagedQuery<TResponse> : IQuery<TResponse>
{
    PaginationOptions PaginationOptions { get; set; }
}

public class PagedQuery<TResponse> : IPagedQuery<TResponse>
{
    public PaginationOptions PaginationOptions { get; set; } = new();
}