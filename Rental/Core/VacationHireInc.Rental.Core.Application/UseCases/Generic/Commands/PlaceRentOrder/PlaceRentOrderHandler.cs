using MediatR;
using VacationHireInc.Rental.Core.Application.Core.Result;
using VacationHireInc.Rental.Core.Application.Data;
using VacationHireInc.Rental.Core.Domain.Models;

namespace VacationHireInc.Rental.Core.Application.UseCases.Cars.PlaceRentOrder;

public class PlaceRentOrderHandler(ICrudRepository<RentOrder> orderRepository) : IRequestHandler<PlaceRentOrderRequest, Result>
{
    public async Task<Result> Handle(PlaceRentOrderRequest request, CancellationToken cancellationToken)
    {
        // Ensure all related items exist and valid

        await orderRepository.CreateAsync(request.Order);

        return Result.Success();
    }
}