using MediatR;

namespace VacationHireInc.Rental.Core.Application.Core.MediatR.Types;

public interface ICommand<T> : IRequest<T>
{
}