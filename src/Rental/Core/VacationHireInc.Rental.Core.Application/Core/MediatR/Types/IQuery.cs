using MediatR;

namespace VacationHireInc.Rental.Core.Application.Core.MediatR.Types;

public interface IQuery<T> : IRequest<T>
{
}