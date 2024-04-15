using MediatR;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Application.Data;
using VacationHireInc.Rental.Core.Domain.Enums;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Generic.Commands.CloseRentOrder;

public class CloseRentOrderHandler(ICrudRepository<RentOrder> orderRepo, ICrudRepository<RentSummary> summaryRepo,
    ICrudRepository<RentItem> itemRepo) 
    : IRequestHandler<CloseRentOrderRequest, Result>
{
    public async Task<Result> Handle(CloseRentOrderRequest request, CancellationToken cancellationToken)
    {
        var order = await orderRepo.GetAsync(request.RentOrderId, cancellationToken);
        if (order is null)
            return Result.Failure();
        
        // ensure order is open
        var item = await itemRepo.GetAsync(order.RentItemId, cancellationToken);
        if (item is null)
            return Result.Failure();
        
        var rentPeriod = (request.Summary!.RentEndDate - order.RentStart).Hours;
        var initialCost = rentPeriod / (int)item.BillingPeriod * item.RentCost;
        request.Summary.Total = initialCost + request.Summary.Rows
            .Where(x => x.Cost.HasValue)
            .Select(x => x.Cost!.Value)
            .Sum();

        await summaryRepo.CreateAsync(request.Summary, cancellationToken);
        order.Status = OrderStatus.Closed;
        await orderRepo.UpdateAsync(order, cancellationToken);
        return Result.Success();
    }
}