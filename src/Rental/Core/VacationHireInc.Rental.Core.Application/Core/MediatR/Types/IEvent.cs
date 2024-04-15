using MediatR;

namespace VacationHireInc.Rental.Core.Application.Core.MediatR.Types;

public interface IEvent<T> : IRequest<T>
{
}